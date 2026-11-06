using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Referencia al valor de puntos del jugador
/// Referencia al valor de velocidad del jugador
/// Referencia al texto q indica el tiempo
/// Referencia a la imagen q representa la vida restante del jugador
/// </summary>
public class UI_FlightCanvas : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    TMP_Text playerPointText;

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
        // Enlazar el evento del manager con un método del canvas (UpdateTime)
        // En la parte izquierda escribo la referencia global al manager
        // En la parte derecha me suscribo a uno de sus eventos
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_FlightSimulator.Instance.OnSpeedChanged += UpdatePlayerSpeedText;
        M_FlightSimulator.Instance.OnLifeChanged += UpdateLifeLeftImage;
        M_FlightSimulator.Instance.OnPointsChanged += UpdatePlayerPointText;
    }
    void UpdatePlayerPointText(int currentPlayerPoints)
    {
        playerPointText.text = currentPlayerPoints.ToString();
    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        playerSpeedText.text = currentPlayerSpeed.ToString();
    }
    void UpdateTimeLeftText(float currentTimeLeft)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }

    void UpdateLifeLeftImage(float currentLife)
    {
        playerLifeImage.fillAmount = currentLife;
    }

    #endregion
}
