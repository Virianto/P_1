using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

/// <summary>
/// Aquí la descripcion de qué hace la clase
/// </summary>
public class UI_GameHudCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button replayGameButton;

    [SerializeField]
    Slider IULifeSlider;

    [SerializeField]
    Button trapControlButton;

    [SerializeField]
    TMP_Text chronoText;

    [SerializeField]
    TMP_Text coinsCounterText;

    float gameplayTime;

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

    private void Update()
    {
        //En cada frame le sumo a mi crono el tiempo transcurrido el último frame
        gameplayTime += Time.deltaTime;

        //chronoText.text = gameplayTime.ToString();
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        //Actualizo el valor del slider para que coincida con los puntos de vida del jugador
        IULifeSlider.value = playerLifePointsLeft;
    }

    //public void UpdateCounter(int playerLifePointsLeft)
    //{
    //    //Actualizo el valor del slider para que coincida con los puntos de vida del jugador
    //    IUCoinsCounter.value = playerLifePointsLeft;
    //}

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EnableControlButton(GameObject controlPlatform, GameObject trapObject)
    {
        //Activamos dependiendo de la trampa/obstaculo
        bool isActTrap = controlPlatform.name.Contains("Act");
        bool isObstacle = controlPlatform.name.Contains("mov");

        //Recibir infomación de la platform y colorear el botón
        trapControlButton.GetComponent<Image>().color = controlPlatform.GetComponentInChildren<Renderer>().material.color;

        //Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        //Vincular OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(isActTrap || isObstacle); }); //Si es trap de activación o movil,
                                                                                                         //activamos en vez de desactivar
    }

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }
    #endregion
}