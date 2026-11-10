using UnityEngine;
using TMPro;

public class VelocimetroUI : MonoBehaviour
{
    public B_PlayerPlane jugador;
    public TextMeshProUGUI textoVelocidad;

    void Update()
    {
        textoVelocidad.text = "S - " + jugador.speed.ToString("00") + " Km/h";
    }
}