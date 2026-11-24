using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// * Referencia al valor de puntos del jugador
/// * Referencia al valor de velocidad del jugador
/// * Referencia al texto que indica el tiempo
/// * Referencia a la imagen que representa la vida restante del jugador
/// </summary>
public class UI_FlightSimulatorCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    TMP_Text playerPointsText;

    [SerializeField]
    TMP_Text playerSpeedText;

    [SerializeField]
    TMP_Text timeLeftText;

    [SerializeField]
    Image playerLifeImage;

    #endregion

    #region METHODS

    void Start()
    {       
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;

        M_FlightSimulator.Instance.OnPlayerLifeLeftChanged += UpdateLifeLeftImage;

        player.OnPlayerSpeedChanged += UpdatePlayerSpeedText;
    }

    void UpdatePlayerPointsText(int currentPlayerPoints)
    {

    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        playerSpeedText.text = string.Format("Speed: {0:000} Km/h", currentPlayerSpeed);
    }

    void UpdateTimeLeftText(float currentTimeLeft) 
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }

    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
    }

    #endregion
}
