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
        // Enlazar el evento del manager con un método del canvas (updateTime)
        // En la parte izquierda escribo la referencia global al manager
        // En la parte derecha me suscribo a uno de sus eventos
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
    }

    void UpdatePlayerPointsText(int currentPlayerPoints)
    {

    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {

    }

    void UpdateTimeLeftText(float currentTimeLeft) 
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }

    void UpdateLifeLeftImage(float currentAmountLeft)
    {

    }

    #endregion
}
