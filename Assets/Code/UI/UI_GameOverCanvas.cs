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

    //[SerializeField]
    //Slider IULifeSlider;

    //[SerializeField]
    //Button trapControlButton;

    [SerializeField]
    TMP_Text chronoText;

    [SerializeField]
    TMP_Text coinsCounterText;

    float gameplayTime;

    #endregion

    #region METHODS

    // Método público para actualizar su mensaje de fin de juego

    #endregion

    #region METHODS
    
    private void Awake()
    {
        //replayGameButton.onClick.AddListener(ResetGame);
        coinsCounterText.text = "00";
        chronoText.text = "00:00:00";
    }
    //void Awake()
    //{
    //    // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
    //    coinsCounterText.text = "00";

    //    //replayGameButton.onClick.AddListener(ResetGame);
    //}

    public void UpdateCounter(int coinsCollected)
    {
        // Convierto el número en una cadena [1 -> "1"] y lo muestro en el texto de la UI
        coinsCounterText.text = coinsCollected.ToString();
    }

    //private void Update()
    //{
    //    //En cada frame le sumo a mi crono el tiempo transcurrido el último frame
    //    gameplayTime += Time.deltaTime;

    //    //chronoText.text = gameplayTime.ToString();
    //    chronoText.text = TimeFormatter.FormatTime(gameplayTime);
    //}

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
