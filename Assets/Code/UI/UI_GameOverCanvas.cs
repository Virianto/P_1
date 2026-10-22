using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button replayGameButton;

    [SerializeField]
    Slider IULifeSlider;

    [SerializeField]
    Button trapControlButton;

    #endregion

    #region METHODS

    // Método público para actualizar su mensaje de fin de juego

    #endregion

    #region METHODS
    void Awake()
    {
        //replayGameButton.onClick.AddListener(ResetGame);
    }
    //void Awake()
    //{
    //    // Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
    //    coinsCounterText.text = "00";

    //    //replayGameButton.onClick.AddListener(ResetGame);
    //}

    //public void UpdateCounter(int coinsCollected)
    //{
    //    // Convierto el número en una cadena [1 -> "1"] y lo muestro en el texto de la UI
    //    coinsCounterText.text = coinsCollected.ToString();
    //}

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        //Actualizo el valor del slider para que coincida con los puntos de vida del jugador
        IULifeSlider.value = playerLifePointsLeft;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EnableControlButton(GameObject trapObject)
    {
        //Cojo el botón de referencia y lo hago interactivo
        trapControlButton.interactable = true;

        //Vincular OnClick del botón con el objeto de la trampa
        trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });
    }

    void DisableTrap(GameObject trapObject)
    {
        trapControlButton.interactable = false;
    }

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }

    #endregion
}
