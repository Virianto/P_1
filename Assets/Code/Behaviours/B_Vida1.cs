using UnityEngine;

public class B_Vida1 : MonoBehaviour
{
    #region attributes
    public float vidaMaxima = 100f;
    public float vida;

    [HideInInspector] public GeneradorAgentes generador;

    bool muerto;
    #endregion
    #region METHODS
    // Se ejecuta cada vez que el objeto aparece (también al reutilizarlo del pool)
    void OnEnable()
    {
        vida = vidaMaxima;
        muerto = false;
    }

    public void RecibirDano(float cantidad)
    {
        if (muerto) return;

        vida -= cantidad;
        if (vida <= 0f)
            Morir();
    }

    void Morir()
    {
        muerto = true;

        if (generador != null)
        {
            var agente = GetComponent<B_Agente>();
            generador.Devolver(agente);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}