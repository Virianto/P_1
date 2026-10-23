using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    TMP_Text coinsCounterText;

    [SerializeField]
    TMP_Text Chronotext;
    [SerializeField]
    Slider playerLifeSlider;

    [SerializeField]
    Button trapControlButton;

    float gamePlayTime = 0;
    #endregion

    #region METHODS

    void Awake()
    {
        // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";
        Chronotext.text = "00:00:00";

    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierto el número en una cadena [1 -> "1"] y lo muestro en el texto de la UI
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        // Actualizo el valor del slider para que coincida con los puntos de vida del jugador
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void EnableControlButton(GameObject trapObject)
    {
        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });
    }

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        gamePlayTime += Time.deltaTime;  

        Chronotext.text = gamePlayTime.ToString();
        Chronotext.text = TimeFormatter.FormatTime(gamePlayTime);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
