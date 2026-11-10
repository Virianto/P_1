using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_RestarVida : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;

    public Image barraVida;
    public TextMeshProUGUI textoVida;

    void OnEnable()
    {
        ZonaDaño.OnDañoRecibido += RestarVida;
    }

    void OnDisable()
    {
        ZonaDaño.OnDañoRecibido -= RestarVida;
    }

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarUI();
    }

    public void RestarVida(float cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual < 0) vidaActual = 0;

        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (barraVida != null)
            barraVida.fillAmount = vidaActual / vidaMaxima;

        if (textoVida != null)
            textoVida.text = vidaActual.ToString("00");
    }
}