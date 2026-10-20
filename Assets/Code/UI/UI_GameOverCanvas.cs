using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public GameManager gameManager;

    [SerializeField]
    Button replayGameButton;

    #endregion

    #region METHODS

    void Awake()
    {
        replayGameButton.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
