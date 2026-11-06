using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class Ui_SimulatorCnavas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    TMP_Text playerPointText;

    [SerializeField]
    TMP_Text TimeLeftText;
    [SerializeField]
    TMP_Text PlayerSpeedText;

    [SerializeField]
    Image playerLifeImage;
    #endregion


    #region METHODS 
    void Start()
    {
        M_simulador.Instance.OnTimeLeftChanged += UpdateTimeLeftText;

        M_simulador.Instance.OnPlayerLifeLeftChanged += UpdateLifeLeftImage;
    }
    void UpdatePlayerPointTex(int currentPlayerPoints)
    {

    }

    void UpdateTimeLeftText(float currentTimeLeft)
    {
        TimeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }
    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
   
    }
    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
    }

    


    #endregion
}
