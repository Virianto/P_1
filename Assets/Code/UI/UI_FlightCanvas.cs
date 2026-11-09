using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class UI_FlightCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    TMP_Text playerPointsText;

    [SerializeField]
    TMP_Text playerSpeedTest;

    [SerializeField]
    TMP_Text timeLeftText;

    [SerializeField]
    Image planeDamage;

    [SerializeField]
    Image playerLifeImage;

    #endregion
    #region METHODS

    private void Start()
    {
        M_ManagerCanvasAvion.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_ManagerCanvasAvion.Instance.PointsChanged += UpdatePlayerPointsText;
        M_ManagerCanvasAvion.Instance.SpeedChanged += UpdatePlayerSpeedText;
        M_ManagerCanvasAvion.Instance.PlaneStatus += UpdateLifeLeftImage;
        M_ManagerCanvasAvion.Instance.OnPlayerLifeLeftChanged += UpdateLifeLeftImage;
    }

    void UpdatePlayerPointsText(int currentPlayerPoints)
    {
        playerPointsText.text = currentPlayerPoints.ToString();
    }
    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        playerSpeedTest.text = currentPlayerSpeed.ToString();
    }
    void UpdateTimeLeftText(float currentTimeLeft)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }
    void UpdateLifeLeftImage(string indicatorStatus)
    {
        if (indicatorStatus == "Red")
        {
            planeDamage.color = Color.red;
        }
    }
    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
    }
    #endregion
}

