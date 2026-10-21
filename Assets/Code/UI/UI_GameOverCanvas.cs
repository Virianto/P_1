using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    TMP_Text coinsCounterText;

    [SerializeField]
    Button replayGameButton;

    [SerializeField]
    Slider playerLifeSlider;

    #endregion

    #region METHODS

    void Awake()
    {
        // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";

        //replayGameButton.onClick.AddListener(ResetGame);
    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierto el número en una cadena [1 -> "1"] y lo muestro en el texto de la UI
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
