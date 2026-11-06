using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Informar de los distintos parámetros, como la vida, el tiempo restante, etc
/// * Referencia al valor de puntos del jugador
/// * Referencia al valor de velocidad del jugador
/// * Referencia al tiempo restante
/// * Referencia a la vida del jugador
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
        // Enlazar el evento del Manager con un método del Canvas

        // En la parte izquierda escribimos la referencia global al Manager
        // En la parte derecha nos suscribimos a una de sus eventos

        M_FlightSimulator.Instance.OnPointsChanged += UpdatePlayerPointsText;
        M_FlightSimulator.Instance.OnSpeedChanged += UpdatePlayerSpeedText;
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_FlightSimulator.Instance.OnLifeChanged += UpdateLifeLeftImage;

    }

    void UpdatePlayerPointsText(float currentPlayerPoints)
    {
        playerPointsText.text = string.Format("Points: {0}", currentPlayerPoints);
    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        playerSpeedText.text = string.Format("Speed: {0} km/h", currentPlayerSpeed);
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