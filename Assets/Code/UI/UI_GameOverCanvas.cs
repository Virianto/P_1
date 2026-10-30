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

    [SerializeField]
    TMP_Text cronoText;

    [SerializeField]
    Button trapControlButton;

    [SerializeField]
    Slider playerLifeSlider;

    float gameplayTime = 0;


    #endregion

    #region METHODS

    void Awake()
    {
        coinsCounterText.text = "00";
        cronoText.text = "00:00:00";
    }
    private void Update()
    {
        //en cada frame le sumo al cron oel tiempo transcurrido 
        gameplayTime += Time.deltaTime; 

        cronoText.text = TimeFormatter.FormatTime(gameplayTime);
    }

    public void UpdateCounter(int coinsCollected)
    {
        // convierto el numero en una cadena 1 ->"1" y lo muestro en el texto de la UI
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        //actualizo el valor del slider para que coincida con el hp del player
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void EnableControlButton(GameObject controlPlatfrom, GameObject trapObject)
    {
        trapControlButton.GetComponent<Image>().color = controlPlatfrom.GetComponent<Renderer>().material.color;

        trapControlButton.interactable = true;

        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false);  });

        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });

        //recibir informacion de la plataforma y colorear el button en consonancia
    }

    public void EnableDynamicTrapButton(GameObject controlPlatform, GameObject B_DynamicObstacle)//obstacle
    {
        trapControlButton.interactable = true;
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
