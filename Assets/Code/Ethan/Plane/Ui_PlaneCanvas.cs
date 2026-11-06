using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_PlaneCanvas : MonoBehaviour
{
    [SerializeField] M_FlightSim PlaneManager;
    [SerializeField] TMP_Text playerPointsText;
    [SerializeField] TMP_Text PlayerSpeedText;
    [SerializeField] TMP_Text timer;
    [SerializeField] Image playerLifeImage;
    void UpdatePlayerPoints(int currentPlayerPoints)
    {
        
    }
    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {

    }
    void UpdateTimeLeftText(float currentTimeLeft)
    {

    }
    void UpdateLifeLeftImage(float currentAmountLeft)
    {

    }

    void Start()
    {
        PlaneManager = GetComponent<M_FlightSim>();
    }
}
