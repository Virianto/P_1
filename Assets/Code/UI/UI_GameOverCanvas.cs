using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    B_FakeTrap trapTag;

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

    private void Update()
    {
        gameplayTime += Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);
    }

    public void UpdateCounter(int coinsCollected)
    {
        // Convierto el número en una cadena [1 -> "1"] y lo muestro en el texto de la UI
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void UpdateLifeSlider(int playerLifePointsLeft)
    {
        playerLifeSlider.value = playerLifePointsLeft;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EnableControlButton(GameObject trapObject)
    {
        trapControlButton.interactable = true;

        if (trapTag.tag == "Trap")
        {
            trapControlButton.onClick.AddListener(() => { trapObject.SetActive(false); });
        }
        if (trapTag.tag == "TrapCoin")
        {
            trapControlButton.onClick.AddListener(() => { trapObject.SetActive(true); });
            

        }
    }

    public void DisableControlButton()
    {
        trapControlButton.interactable = false;
    }

    

    #endregion
}
