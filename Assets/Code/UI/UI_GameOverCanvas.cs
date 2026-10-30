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
    TMP_Text chronoText;

    [SerializeField]
    Slider playerLifeSlider;

    [SerializeField]
    Button trapControlButton;

    float gameplayTime = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";
        chronoText.text = "00:00:00";
    }

    void Update()
    {
        // En cada frame le sumo a mi crono el tiempo transcurrido el último frame
        gameplayTime += Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);
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

    public void EnableControlButton(GameObject controlPlatform, GameObject trapObject)
    {
        // Colorear el botón en consonancia
        trapControlButton.GetComponent<Image>().color 
            = controlPlatform.GetComponent<Renderer>().material.color;

        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });
    }

    public void EnableObstacleControlButton(GameObject platform, B_DynamicObstacle obstacle)
    {
        // Activar el botón
        trapControlButton.interactable = true;

        // Vincular el botón a una variable que active mi obstáculo
        trapControlButton.onClick.AddListener(() => { obstacle.shouldMove = true; });
    }

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
