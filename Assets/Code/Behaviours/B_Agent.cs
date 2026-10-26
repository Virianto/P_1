using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hasta ese punto por el camino más óptimo q encuentre
    #region ATTRIBUTES
    NavMeshAgent myAgent;


    #endregion


    #region METHODS
    public void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 NewDestination)
    {
        // Cambiar el destino de mi agente
        myAgent.SetDestination(NewDestination);
    }


    #endregion
}
