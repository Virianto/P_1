using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class B_Agente : MonoBehaviour
{
    public Transform objetivo;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Si no tiene objetivo, busca al jugador por su etiqueta
        if (objetivo == null)
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
                objetivo = player.transform;
            else
                return;
        }

        if (!nav.isActiveAndEnabled || !nav.isOnNavMesh) return;

        nav.SetDestination(objetivo.position);
    }
}