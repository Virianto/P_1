using UnityEngine;
using System;

public class ZonaDaño : MonoBehaviour
{
    // Evento: avisa de que se ha hecho daño
    public static event Action<float> OnDañoRecibido;

    public float radio = 6f;
    public float daño = 10f;
    public float segundosEntreGolpes = 1f;

    B_PlayerPlane jugador;
    float proximoGolpe = 0f;

    void Start()
    {
        jugador = FindFirstObjectByType<B_PlayerPlane>();
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.transform.position);

        if (distancia < radio && Time.time >= proximoGolpe)
        {
            proximoGolpe = Time.time + segundosEntreGolpes;
            OnDañoRecibido?.Invoke(daño);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}