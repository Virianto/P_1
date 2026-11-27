using UnityEngine;

public class RutaCubo : MonoBehaviour
{
    public Transform[] puntos;      // los puntos de la ruta, en orden
    public float velocidad = 3f;
    public bool repetir = true;     // al llegar al último, vuelve al primero
    public float distanciaLlegada = 0.05f;

    int indice = 0;

    void Update()
    {
        if (puntos == null || puntos.Length == 0) return;
        SeguirRuta();
    }

    void SeguirRuta()
    {
        Transform destino = puntos[indice];

        transform.position = Vector3.MoveTowards(
            transform.position,
            destino.position,
            velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino.position) < distanciaLlegada)
        {
            indice++;

            if (indice >= puntos.Length)
            {
                if (repetir) indice = 0;
                else
                {
                    indice = puntos.Length - 1;
                    enabled = false;   // termina la ruta
                }
            }
        }
    }
}