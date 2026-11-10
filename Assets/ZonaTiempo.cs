using UnityEngine;
using System;

public class ZonaTiempo : MonoBehaviour
{
    // Evento: avisa de que hay que sumar segundos
    public static event Action<float> OnTiempoSumado;

    public float radio = 6f;
    public float segundos = 40f;

    B_PlayerPlane jugador;
    bool usado = false;

    void Start()
    {
        jugador = FindFirstObjectByType<B_PlayerPlane>();
    }

    void Update()
    {
        if (usado || jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.transform.position);

        if (distancia < radio)
        {
            usado = true;
            OnTiempoSumado?.Invoke(segundos);
            gameObject.SetActive(false);   // desaparece al cogerlo
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}