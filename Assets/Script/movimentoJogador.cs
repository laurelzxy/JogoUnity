using UnityEngine;

public class movimentoJogador : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCamera;
    private Animator animator;

    private bool estaNoChao;
    [SerializeField] private Transform pePlayer;
    [SerializeField] private LayerMask colisaoLayer;


    private float forcaY;

    private int currentJumpCount = 0;
    private int maxJumpCount = 2;

    public float velocidadeBase = 5f;
    [HideInInspector] public float velocidadeAtual;
    public GameObject efeitoBuff;


  

    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
        animator = GetComponent<Animator>();

        velocidadeAtual = velocidadeBase;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = myCamera.TransformDirection(movimento);
        movimento.y = 0;


        controller.Move(movimento * Time.deltaTime * velocidadeAtual);


        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }


        animator.SetBool("Mover", movimento != Vector3.zero);


        estaNoChao = Physics.CheckSphere(pePlayer.position, 0.3f, colisaoLayer);
        animator.SetBool("EstarNoChao", estaNoChao);

        if (estaNoChao && forcaY < 0)
        {
            currentJumpCount = 0; // Reseta os pulos quando encosta no chão
            forcaY = -1f; // mantém pressionado contra o chão
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount < maxJumpCount)
        {
            if (currentJumpCount == 0)
            {
                forcaY = 5f; // Primeiro pulo
            }
            else
            {
                forcaY = 7.5f; // Segundo pulo mais forte 
            }

            currentJumpCount++;
            animator.SetTrigger("Saltar");
            Debug.Log("Pulou: " + currentJumpCount);
        }

        if (forcaY > -9.81f)
        {
            forcaY += -9.81f * Time.deltaTime;
        }

        controller.Move(new Vector3(0, forcaY, 0) * Time.deltaTime);

        //void die()
        //{
        //    velocidadeAtual = velocidadeBase;

        //    if (efeitoBuff != null)
        //        efeitoBuff.SetActive(false);

        //    // Outras coisas como animação de morte, desativar controle, etc.
        //}
    }
}