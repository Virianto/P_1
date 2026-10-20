using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    TMP_Text coinsCounterText;

    //[SerializeField]
    //Button replayGameButton;

    #endregion

    #region METHODS

    void Awake()
    {
        coinsCounterText.text = "00";

        //replayGameButton.onClick.AddListener(ResetGame);
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
