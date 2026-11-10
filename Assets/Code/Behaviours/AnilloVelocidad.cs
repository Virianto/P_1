using UnityEngine;
using System.Collections;

public class AnilloVelocidad : MonoBehaviour
{
    #region ATTRIBUTES
    public float radio = 5f;           // lo cerca que tiene que pasar el avión
    public float multiplicador = 2f;   // 2 = doble de rápido, 0.5 = la mitad
    public float duracion = 3f;        // segundos que dura el efecto

    B_PlayerPlane jugador;
    bool usado = false;
    #endregion
    #region methods
    void Start()
    {
        // Busca el avión de la escena automáticamente
        jugador = FindObjectOfType<B_PlayerPlane>();

        if (jugador == null)
            Debug.LogError("AnilloVelocidad: no encuentro ningún B_PlayerPlane en la escena");
        else
            Debug.Log("Anillo listo: " + gameObject.name);
    }

    void Update()
    {
        if (usado || jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.transform.position);

        if (distancia < radio)
        {
            usado = true;
            Debug.Log("Anillo activado: " + gameObject.name + " | velocidad antes: " + jugador.speed);

            jugador.StartCoroutine(CambiarVelocidad(jugador));
            gameObject.SetActive(false);
        }
    }

    IEnumerator CambiarVelocidad(B_PlayerPlane p)
    {
        p.speed *= multiplicador;
        Debug.Log("Velocidad ahora: " + p.speed);

        yield return new WaitForSeconds(duracion);

        p.speed /= multiplicador;
        Debug.Log("Velocidad restaurada: " + p.speed);
    }

    // Dibuja una esfera amarilla en Scene al seleccionar el anillo para ver el radio
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
    #endregion
}