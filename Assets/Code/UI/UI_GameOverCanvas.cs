using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button trapControlButton;

    [SerializeField]
    TMP_Text coinsConterText;

    [SerializeField]
    Slider playerLifeSlider;

    [SerializeField]
    TMP_Text chronoText;

    float gamePlayTime = 0; // Cuenta en segundos

    [SerializeField]
    GameObject dynamicObstacle;

    #endregion

    #region METHODS

    void Awake()
    {
        // replayGameButton.onClick.AddListener(ResetGame);

        coinsConterText.text = "00";
        chronoText.text = "00:00:00";
    }

    public void Update()
    {
        // En cada frame le sumo a mi crono el tiempo transurrido desde el último frame
        gamePlayTime += Time.deltaTime; //Si quiero hacer una cuenta atrás le doy tiempo en gamePlayTime y pongo aquí -=

        chronoText.text = TimeFormatter.FormatTime(gamePlayTime);
    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierno el número en cadena (1 -> "1") y lo muestro en el texto de la UI
        coinsConterText.text = coinsCollected.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        // Actualizo el valor del slider para q coincida con la cantidad de puntos de vida del jugador
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void EnableControlButton(GameObject controlPlataform, GameObject trapObject, GameObject dynamicObstacle) // Recibir info de la plataforma de control
    {
        // Colorear el botón en consonancia con el color/material de la plataforma
        trapControlButton.GetComponent<Image>().color = controlPlataform.GetComponent<Renderer>().material.color;

        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); }); ; //FUNCIÓN ANÓNIMA

        // Vincular el hacer click en el botón con el objeto dinámico q hemos añadido
        trapControlButton.onClick.AddListener(() => { dynamicObstacle.SetActive(true); }); ;
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
