using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameOverCanvas2 : MonoBehaviour
{
    public M_GameManager gameManager;

    //Esta clase se va a encargar de vincular al botón del canvas la funcionalidad de cambiar de escena

    //Referencia al botón
    [SerializeField]
    Button replayGameButton;

    private void Awake()
    {
        //Como ya tengo mi referencia al botón, lo puedo vincular a métodos publicos
        replayGameButton.onClick.AddListener(ReLaunchGame);
    }

    public void ReLaunchGame()
    {
        //El 1 aquí en el índice de mi escena del juego
        SceneManager.LoadScene(0);
    }

    //Método público para actualizar el mensaje fin
}
