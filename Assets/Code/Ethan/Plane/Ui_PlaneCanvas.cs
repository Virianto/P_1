using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_PlaneCanvas : MonoBehaviour 
{
    [SerializeField] M_FlightSim planeManager;
    [SerializeField] TMP_Text playerPointsText;
    [SerializeField] TMP_Text playerSpeedText;
    [SerializeField] TMP_Text timer;
    [SerializeField] Image playerLifeImage;

    void Start()
    {
        planeManager = GetComponent<M_FlightSim>();
        M_FlightSim.Instance.OnTimeLeftChange += UpdateTimeLeftText;
        M_FlightSim.Instance.OnPointsChange += UpdatePlayerPoints;
        M_FlightSim.Instance.OnPlayerLifeLeftChanged += UpdateLifeLeftImage;
    }

    public void UpdatePlayerPoints(int currentPlayerPoints)
    {
        playerPointsText.text = currentPlayerPoints.ToString();
    }
    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {

    }
    void UpdateTimeLeftText(float currentTimeLeft)
    {
        timer.text = TimeFormatter.FormatTime(currentTimeLeft);
    }
    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
    }
}
