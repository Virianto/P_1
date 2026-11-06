using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class F_UI_FlightSimulatorCanvas : MonoBehaviour
{
    #region ATTRIBUTES

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
        // Me sintonizo a los eventos del manager
        F_M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        F_M_FlightSimulator.Instance.OnLifeChanged += UpdateLifeLeftImage;
        F_M_FlightSimulator.Instance.OnPointsChanged += UpdatePlayerPointsText;
        F_M_FlightSimulator.Instance.OnSpeedChanged += UpdatePlayerSpeedText;
    }

    void OnDestroy()
    {
        // Me desuscribo para no dejar enlaces colgados
        if (F_M_FlightSimulator.Instance != null)
        {
            F_M_FlightSimulator.Instance.OnTimeLeftChanged -= UpdateTimeLeftText;
            F_M_FlightSimulator.Instance.OnLifeChanged -= UpdateLifeLeftImage;
            F_M_FlightSimulator.Instance.OnPointsChanged -= UpdatePlayerPointsText;
            F_M_FlightSimulator.Instance.OnSpeedChanged -= UpdatePlayerSpeedText;
        }
    }

    void UpdatePlayerPointsText(int currentPlayerPoints)
    {
        playerPointsText.text = currentPlayerPoints.ToString();
    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        playerSpeedText.text = currentPlayerSpeed.ToString("F1");
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