using UnityEngine;
using UnityEngine.AI;

public class A_Agent : MonoBehaviour
{
    A_AgentsManager myManager;
    int lifepoints = 3;
    NavMeshAgent myNavMeshAgent;

    public void InitializeNewAgent (A_AgentsManager manager, Vector3 origin,Vector3 destiny)
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myManager = manager;
        myNavMeshAgent.SetDestination(destiny);
        transform.position = origin;

    }


}
