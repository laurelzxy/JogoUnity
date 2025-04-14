using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Este método será chamado quando o botão "Jogar" for clicado
    public void Jogar()
    {
        // Carrega a próxima cena (certifique-se de adicioná-la no Build Settings)
        SceneManager.LoadScene("SampleScene"); // substitua pelo nome real da cena
    }

    // Este método será chamado quando o botão "Opções" for clicado
    public void Opcoes()
    {
        // Aqui você pode abrir um painel de opções
        Debug.Log("Abrir menu de opções");
    }

    // Este método será chamado quando o botão "Sair" for clicado
    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Funciona somente no build final
    }
}

