using UnityEngine;

public class GeneradorAgentes : MonoBehaviour
{
    public GameObject prefab;            // El agente que se va a crear
    public Transform[] puntosSpawn;      // Sitios donde aparecen
    public float intervalo = 2f;         // Segundos entre cada agente
    public int maxAgentes = 10;          // Máximo de agentes a la vez

    float temporizador;
    int siguientePunto;

    void Update()
    {
        // Cuenta el tiempo
        temporizador += Time.deltaTime;

        if (temporizador >= intervalo)
        {
            temporizador = 0f;
            CrearAgente();
        }
    }

    void CrearAgente()
    {
        // 1. Comprobaciones
        if (prefab == null)
        {
            Debug.LogWarning("Falta arrastrar el Prefab en el Generador.", gameObject);
            return;
        }

        if (puntosSpawn.Length == 0)
        {
            Debug.LogWarning("No hay Puntos Spawn en el Generador.", gameObject);
            return;
        }

        // Los agentes son hijos del Generador, así que contamos sus hijos
        if (transform.childCount >= maxAgentes) return;

        // 2. Busca el siguiente punto que no esté vacío
        Transform punto = null;

        for (int i = 0; i < puntosSpawn.Length; i++)
        {
            Transform candidato = puntosSpawn[siguientePunto];
            siguientePunto = (siguientePunto + 1) % puntosSpawn.Length;

            if (candidato != null)
            {
                punto = candidato;
                break;
            }
        }

        if (punto == null)
        {
            Debug.LogWarning("Todos los huecos de Puntos Spawn están vacíos (None).", gameObject);
            return;
        }

        // 3. Crea el agente justo en ese punto
        Instantiate(prefab, punto.position, punto.rotation, transform);
    }
}