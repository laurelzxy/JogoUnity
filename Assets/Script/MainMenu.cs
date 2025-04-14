using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Este m�todo ser� chamado quando o bot�o "Jogar" for clicado
    public void Jogar()
    {
        // Carrega a pr�xima cena (certifique-se de adicion�-la no Build Settings)
        SceneManager.LoadScene("SampleScene"); // substitua pelo nome real da cena
    }

    // Este m�todo ser� chamado quando o bot�o "Op��es" for clicado
    public void Opcoes()
    {
        // Aqui voc� pode abrir um painel de op��es
        Debug.Log("Abrir menu de op��es");
    }

    // Este m�todo ser� chamado quando o bot�o "Sair" for clicado
    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Funciona somente no build final
    }
}

