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
    Button coinTrapControlButton;
    [SerializeField]
    Button obstacleTrapControlButton;

    [SerializeField]
    TMP_Text coinsCounterText;

    [SerializeField]
    Slider playerLifeSlider;

    [SerializeField]
    TMP_Text chronoText;

    float gameplayTime = 0;


    #endregion

    #region METHODS

    void Awake()
    {
        //Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";
        chronoText.text = "00:00:00";
    }

    public void UpdateCounter(int coinsCollected)
    {
        coinsCounterText.text = coinsCollected.ToString();
    }


    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        //Actualizo el valor del slider para que coincida con los puntos de vida del jugador
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void EnableControlButton(GameObject controlPlatform, GameObject trapObject)
    {
        
        //Colorear el botón en consonancia
        trapControlButton.GetComponent<Image>().color = controlPlatform.GetComponent<Renderer>().material.color;
        
        //Cojo el botón de referencia y lo hago interacctivo
        trapControlButton.interactable = true;

        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false);});
      
    }
  

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }
    public void EnableObstacleControlButton(GameObject obstaclePlatform, GameObject trapObject)
    {
        obstacleTrapControlButton.GetComponent<Image>().color = obstaclePlatform.GetComponent<Renderer>().material.color;
        obstacleTrapControlButton.interactable = true;
        obstacleTrapControlButton.onClick.AddListener(() => { trapObject.SetActive(true); });
    }
    public void EnableCoinTrapButton(GameObject coinPlatform, GameObject trapObject)
    {
        coinTrapControlButton.GetComponent<Image>().color = coinPlatform.GetComponent<Renderer>().material.color;
        coinTrapControlButton.interactable = true;
        coinTrapControlButton.onClick.AddListener(() => {trapObject.SetActive(true);});
    }
    public void DisableObstacleTrapButton()
    {
        obstacleTrapControlButton.interactable = false;
    }
    public void DisableCoinTrapButton()
    {
        coinTrapControlButton.interactable = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        //En cada frame le sumo a mi crono l tiempo transcurrido el último frame
        gameplayTime += Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);

    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
