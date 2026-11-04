using UnityEngine;

public class B_Trampa : MonoBehaviour
{
    public float danoPorSegundo = 20f;   // daño a los agentes (por segundo)
    public int danoJugador = 1;          // daño al jugador (al entrar)

    void OnTriggerStay(Collider other)
    {
        var vida = other.GetComponentInParent<B_Vida1>();
        if (vida != null)
            vida.RecibirDano(danoPorSegundo * Time.deltaTime);
    }
}