using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button trapControlButton;
    [SerializeField]
    TMP_Text coinsCounterText;
    [SerializeField] Slider playerLifeSlider;

    #endregion

    #region METHODS

    void Awake()
    {
        coinsCounterText.text = "0";
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

    public void EnableControlButton(GameObject trapObject)
    {
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
        Debug.Log("enableControlButton");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    // Método público para actualizar su mensaje de fin de juego

    #endregion
}
