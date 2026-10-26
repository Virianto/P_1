using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    NavMeshAgent myAgent;


    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }
}

