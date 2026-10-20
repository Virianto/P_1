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
    TMP_Text coinsCounterText;
    #endregion

    #region METHODS

    void Awake()
    {
        //Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";

        replayGameButton.onClick.AddListener(ResetGame);
    }

    public void UpdateCounter(int coinsCollected)
    {
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
