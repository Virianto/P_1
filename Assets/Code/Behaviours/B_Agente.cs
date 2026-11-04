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
        // Busca al jugador si todavía no lo tiene
        if (objetivo == null)
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (player == null)
            {
                Debug.LogWarning("No encuentro ningún objeto con el Tag 'Player'.", gameObject);
                return;
            }

            objetivo = player.transform;
        }

        if (!nav.isOnNavMesh)
        {
            Debug.LogWarning("El agente no está sobre el NavMesh.", gameObject);
            return;
        }

        nav.SetDestination(objetivo.position);
    }
}