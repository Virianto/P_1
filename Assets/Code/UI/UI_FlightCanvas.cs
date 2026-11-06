using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// * Referencia al valor de puntos del jugador
/// * Referencia al valor de velocidad del jugador
/// * Referencia al texto que indica el tiempo
/// * Referencia a la imagen que representa la vida restante del jugador
/// </summary>
public class UI_FlightCanvas : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    TMP_Text timeLeftText;

    [SerializeField]
    TMP_Text playerScoreText;

    [SerializeField]
    TMP_Text playerSpeedText;

    [SerializeField]
    Image playerLifeImage;
    #endregion


    #region METHODS

    void Start()
    {
        //Enlazar el evento del manager con un evento del canvas (UpdateTime)   
        //En la parte izquierda escribo la referencia global al manager
        // En la parte derecha me suscribo a uno de sus eventos

        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_FlightSimulator.Instance.OnPointCountChanged += UpdatePlayerScoreText;
        M_FlightSimulator.Instance.OnPlayerSpeedChanged += UpdatePlayerSpeedText;
        M_FlightSimulator.Instance.OnPlayerCurrentLifeChanged += UpdateLifeLeftImage;
    }

    void UpdatePlayerScoreText(int currentPlayerScore)
    {
        playerScoreText.text = currentPlayerScore.ToString();
    }

    void UpdatePlayerSpeedText(float  currentPlayerSpeed) 
    {
        playerSpeedText.text = currentPlayerSpeed.ToString();
    }

    void UpdateTimeLeftText(float currentTimeLeft) 
    {
        timeLeftText.text =TimeFormatter.FormatTime(currentTimeLeft);
    }

    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
    }

    #endregion
}
