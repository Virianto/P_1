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
    Button trapControlButton;

    [SerializeField]
    Slider playerLifeSlider;

    #endregion

    #region METHODS

    void Awake()
    {
        // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";

        //replayGameButton.onClick.AddListener(ResetGame);
    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierte el núnmreo en una cadena [1 -> "1"] 
        coinsCounterText.text += coinsCollected.ToString();


    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        // Actualiza el valor del slider para que coincida con los puntos de vida del jugador
        playerLifeSlider.value = playerLifePointsLeft;

    }

    public void EnableControlButton(GameObject trapObject)
    {

        // Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        // Vincular el OnClick del botón cno el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });



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
