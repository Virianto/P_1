using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
        coinsCounterText.text = "00";
        //replayGameButton.onClick.AddListener(ResetGame);
    }

    public void UpdateCounter(int coinsCollector)
    {
        coinsCounterText.text = coinsCollector.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
