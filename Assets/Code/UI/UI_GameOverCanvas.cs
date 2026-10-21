using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button replayGameButton;
    [Serializable]


    #endregion

    #region METHODS

    void Awake()
    {
        replayGameButton.onClick.AddListener(ResetGame);
        coinsCounterText.text = "00";
    }
    public void UpdateCounter(int CoinsCollected)
        coinsCounterText.Text = coinsCollected.ToString
    {
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);

    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
