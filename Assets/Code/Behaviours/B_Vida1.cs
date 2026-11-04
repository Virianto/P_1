using UnityEngine;

public class B_Vida1 : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vida;

    void Start()
    {
        vida = vidaMaxima;
    }

    public void RecibirDano(float cantidad)
    {
        vida -= cantidad;

        if (vida <= 0f)
        {
            Destroy(gameObject);
        }
    }
}