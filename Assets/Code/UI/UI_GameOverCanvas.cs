using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button replayGameButton;

    [SerializeField]
    TMP_Text coinsConterText;

    #endregion

    #region METHODS

    void Awake()
    {
        // replayGameButton.onClick.AddListener(ResetGame);

        coinsConterText.text = "00";
    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierno el número en cadena (1 -> "1") y lo muestro en el texto de la UI
        coinsConterText.text = coinsCollected.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
