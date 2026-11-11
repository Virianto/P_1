using System.Collections;
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

    [SerializeField]
    float displayedSpeed = 100;

    float speedModifier;

    [SerializeField]
    B_PlayerPlane player;

    #endregion





    #region METHODS

    private void Start()
    {
        speedModifier = (displayedSpeed / player.speed);

        // Enlazar el evento del Manager con un método del Canvas
        // * En la parte izquierda escribimos la referencia global al Manager
        // * En la parte derecha nos suscribimos a una de sus eventos

        M_FlightSimulator.Instance.OnPointsChanged += UpdatePlayerPointsText;
        M_FlightSimulator.Instance.OnSpeedChanged += UpdatePlayerSpeedText;
        M_FlightSimulator.Instance.OnTimeLeftChanged += UpdateTimeLeftText;
        M_FlightSimulator.Instance.OnLifeChanged += UpdateLifeLeftImage;

    }

    void UpdatePlayerPointsText(float currentPlayerPoints)
    {
        StartCoroutine(PointsEffect());
        
        playerPointsText.text = string.Format("Points: {0}", currentPlayerPoints);
    }

    IEnumerator PointsEffect()
    {
        // Cambiamos el color del texto
        Color originalColor = playerPointsText.color;
        playerPointsText.color = Color.white;

        // Cambiamos el tamaño del texto
        Vector3 originalScale = playerPointsText.transform.localScale;
        playerPointsText.transform.localScale = originalScale * 2;

        // Esperamos un tiempo
        yield return new WaitForSeconds(2);

        // Volvemos a cambiarlo a su estado original
        playerPointsText.color = originalColor;
        playerPointsText.transform.localScale = originalScale;
    }

    void UpdatePlayerSpeedText(float currentPlayerSpeed)
    {
        StartCoroutine(SpeedEffect());

        playerSpeedText.text = string.Format("Speed: {0} km/h", currentPlayerSpeed * speedModifier);
    }

    IEnumerator SpeedEffect()
    {
        // Cambiamos el color del texto
        Color originalColor = playerSpeedText.color;
        playerSpeedText.color = Color.white;

        // Cambiamos el tamaño del texto
        Vector3 originalScale = playerSpeedText.transform.localScale;
        playerSpeedText.transform.localScale = originalScale * 2;

        // Esperamos un tiempo
        yield return new WaitForSeconds(2);

        // Volvemos a cambiarlo a su estado original
        playerSpeedText.color = originalColor;
        playerSpeedText.transform.localScale = originalScale;
    }

    void UpdateTimeLeftText(float currentTimeLeft)
    {
        timeLeftText.text = TimeFormatter.FormatTime(currentTimeLeft);
    }

    void UpdateLifeLeftImage(float currentAmountLeft)
    {
        StartCoroutine(LifeEffect());

        playerLifeImage.fillAmount = currentAmountLeft;
    }

    IEnumerator LifeEffect()
    {
        // Cambiamos el tamaño de la imagen
        Vector3 originalScale = playerLifeImage.transform.localScale;
        playerLifeImage.transform.localScale = originalScale * 1.5f;

        // Esperamos un tiempo
        yield return new WaitForSeconds(2);

        // Volvemos a cambiarlo a su estado original
        playerLifeImage.transform.localScale = originalScale;
    }

    #endregion
}