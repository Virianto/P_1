using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Referencia al valor de puntos
/// ... al valor de velocidad
/// ... al texto timepo
/// ... a la vida
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
        //Enlazar el evento del manager con un método del canvas (updateTime)
        //En la izquierda escribo referencia al manager
        //En la derecha me suscribo a uno de sus eventos
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
    }

    void UpdatePlayerPointsText(int playerPointsText)
    {

    }

    void UpdatePlayerSpeedText(int playerSpeedText)
    {

    }

    void UpdateTimeLeftText(float currentTimeLeftText)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeftText);
    }

    void UpdateLifeLeftImage()
    {

    }

    #endregion
}
