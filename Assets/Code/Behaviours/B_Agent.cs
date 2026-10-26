using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES
    NavMeshAgent myAgent;
    #endregion

    #region METHODS
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }
    #endregion
}
