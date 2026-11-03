using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_NewAgent : MonoBehaviour
{
    #region ATTRIBUTES
    M_AgentManager agentManager;
    NavMeshAgent myAgent;

    #endregion

    #region METHODS
    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void InitializeAgent(Transform spawnPoint, Transform destinationPoint, M_AgentManager manager)
    {
        agentManager = manager;
        // Set the agent's position to the spawn point
        transform.position = spawnPoint.position;
        // Set the agent's destination
        myAgent.SetDestination(destinationPoint.position);
    }

    void OnTriggerEnter(Collider other)
    {
        agentManager.KillAgent(this);
    }

    
    #endregion
}
