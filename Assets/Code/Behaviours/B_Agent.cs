using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hacia ese punto por el camino más óptimo que encuentre

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    #endregion

    #region METHODS

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }

    #endregion
}
