using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.ComponentModel;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    TMP_Text coinsCounterText;

    [SerializeField]
    Button trapControlButton;

    [SerializeField]
    Slider playerLifeSlider;

    [SerializeField]
    TMP_Text chronoText;



    float gameplayTime = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";
        chronoText.text = "00:00:00";
        //replayGameButton.onClick.AddListener(ResetGame);
    }


    void Update()
    {
        // En cada freame le sumo a mi crono el tiempo transcurrido el último frame
        gameplayTime += Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);

    }


    public void UpdateCounter(int coinsCollected)
    {
        // Convierte el núnmero en una cadena [1 -> "1"] 
        coinsCounterText.text = coinsCollected.ToString();


    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        // Actualiza el valor del slider para que coincida con los puntos de vida del jugador
        playerLifeSlider.value = playerLifePointsLeft;

    }

    public void EnableControlButton(GameObject controlPlatform, GameObject trapObject)
    {

        // Recibir información de la plataforma


        // Colorear el botón en consonancia
        trapControlButton.GetComponent<Image>().color = controlPlatform.GetComponent<Renderer>().material.color;

        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });

    }

    public void EnableObstacleControlButton(GameObject platform, B_DynamicObstacle dynamicObstacle)
    {

        // Activar el botón y vincularlo al obstáculo dinámico
        trapControlButton.interactable = true;

        // Vincular el botón a una variable que active mi obstáculo
        //trapControlButton.onClick.AddListener();
    }

    public void EnableGiveMoney(GameObject controlPlatform, GameObject moneyRain)
    {

        // Recibir información de la plataforma


        // Colorear el botón en consonancia
        trapControlButton.GetComponent<Image>().color = controlPlatform.GetComponent<Renderer>().material.color;

        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { moneyRain.SetActive(true); });




    }

    /*void DisableTrap(GameObject trapObject)
    {

    }*/

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
