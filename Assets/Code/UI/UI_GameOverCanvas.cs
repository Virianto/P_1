using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button trapControlButton;
    [SerializeField] TMP_Text coinsCounterText;
    [SerializeField] Slider playerLifeSlider;
    [SerializeField] TMP_Text chronoText;

    float gameplayTime = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        coinsCounterText.text = "0";
        chronoText.text = "00:00:00";
    }
    void Update()
    {
        //en cada frame le sumo el tiempo transcurrido desde el frame anterior
        gameplayTime += Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);
    }

    public void UpdateCounter(int coinsCollector)
    {
        coinsCounterText.text = coinsCollector.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        //actualizo el valor del slider para que coincida con los puntos de vida del jugador.
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void EnableTrapDoor(GameObject controlPlatform, B_TrapDoor trapDoorObject)
    {
        trapControlButton.interactable = true;
        Debug.Log("EnableTrapDoor Canvas");

        trapControlButton.onClick.AddListener(() => { trapDoorObject.isUp = !trapDoorObject.isUp; trapDoorObject.MoveTrapDoor(); });
        


    }

    public void EnableControlButton(GameObject controlPlatform, GameObject trapObject)
    {
        //controlPlatform.GetComponent<Image>().color = controlPlatform.GetComponent<Renderer>().material.color;
        //cojo el boton de referencia y lo hago interactivo
        trapControlButton.interactable = true;
        Debug.Log("enableControlButton");

        //vincular el OnClick del boton con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });

    }

    public void DisableControlButton()
    {
        //cojo el boton de referencia y lo hago interactivo
        trapControlButton.interactable = false;
        //Debug.Log("enableControlButton");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
