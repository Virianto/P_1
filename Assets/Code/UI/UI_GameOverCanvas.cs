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

    #endregion

    #region METHODS

    void Awake()
    {
        // replayGameButton.onClick.AddListener(ResetGame);

        coinsConterText.text = "00";
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

    public void EnableControlButton(GameObject trapObject)
    {
        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); }); ; //FUNCIÓN ANÓNIMA
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
