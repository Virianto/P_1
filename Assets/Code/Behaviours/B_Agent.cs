using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    // Recibir la orden de dirigirse a un punto del mapa

    // Moverse hacia ese punto por el camino más óptimo que encuentre

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
        // Cambiar el destino del Agente
        myAgent.SetDestination(newDestination);
    }

    #endregion
}
