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

    //Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hacia ese punto por le camino más óptimo que encuentre

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }

    #endregion
}
