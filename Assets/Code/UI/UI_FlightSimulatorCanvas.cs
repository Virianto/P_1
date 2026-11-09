using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// * Referencia al varlor de puntos del jugador
/// * Referencia al valor de velociadad del jugador
/// * Referencia al texto que indica el tiempo
/// * Referencia a la imagen que representa la vida restante del jugador
/// </summary>
public class UI_FlightSimulatorCanvas : MonoBehaviour
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
    private void Start()
    {

        // Enlazar el evento del manager con un método del canvas (updateTime)
        // En la parte izquierda escribo la referencia global al manager
        // En la parte derecha me suscribo a uno de sus eventos
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_FlightSimulator.Instance.OnPlayerLifeChanged += UpdateLifeLeftImage;
        M_FlightSimulator.Instance.OnPointsIncreased += UpdatePlayerPointsText;
        M_FlightSimulator.Instance.OnPlayerSpeedChanged += UpdatePlayerSpeedText;
    }
    private void UpdatePlayerPointsText(float currentPlayerPoints)
    {

        playerPointsText.text = currentPlayerPoints.ToString();

    }

    private void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {

        playerSpeedText.text = currentPlayerSpeed.ToString();

    }

    private void UpdateTimeLeftText(float currentTimeLeft)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);

    }

    private void UpdateLifeLeftImage(float currentAmountLeft)
    {
        playerLifeImage.fillAmount = currentAmountLeft;
        


    }


    #endregion
}