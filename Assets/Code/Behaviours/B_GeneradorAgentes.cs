using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class GeneradorAgentes : MonoBehaviour
{
    [Header("Configuración")]
    public B_Agente prefab;
    public Transform objetivo;
    public Transform[] puntosSpawn;
    public float intervalo = 2f;
    public int maxActivos = 20;

    ObjectPool<B_Agente> pool;

    void Awake()
    {
        pool = new ObjectPool<B_Agente>(
            createFunc: () =>
            {
                var a = Instantiate(prefab);
                var vida = a.GetComponent<B_Vida1>();
                if (vida != null) vida.generador = this;
                return a;
            },
            actionOnGet: a => a.gameObject.SetActive(true),
            actionOnRelease: a => a.gameObject.SetActive(false),
            actionOnDestroy: a => Destroy(a.gameObject),
            defaultCapacity: maxActivos,
            maxSize: maxActivos);
    }

    void Start()
    {
        StartCoroutine(Generar());
    }

    IEnumerator Generar()
    {
        var espera = new WaitForSeconds(intervalo);
        while (true)
        {
            if (pool.CountActive < maxActivos)
                Spawnear();
            yield return espera;
        }
    }

    Vector3 ElegirPosicion()
    {
        if (puntosSpawn != null && puntosSpawn.Length > 0)
        {
            var punto = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            if (punto != null)
                return punto.position;
        }

        // Si no hay puntos de spawn válidos, usa la posición del Generador
        return transform.position;
    }

    void Spawnear()
    {
        if (prefab == null)
        {
            Debug.LogWarning("Falta asignar el Prefab en el Generador.", gameObject);
            return;
        }

        Vector3 pos = ElegirPosicion();

        if (!NavMesh.SamplePosition(pos, out var hit, 5f, NavMesh.AllAreas))
        {
            Debug.LogWarning("La posición de spawn no está cerca del NavMesh (suelo azul).", gameObject);
            return;
        }

        var agente = pool.Get();
        agente.GetComponent<NavMeshAgent>().Warp(hit.position);
        agente.objetivo = objetivo;
    }

    public void Devolver(B_Agente a)
    {
        pool.Release(a);
    }

}