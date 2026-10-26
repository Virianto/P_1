using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    //Recibir la orden de moverse hacia un punto del mapa
    //y va a moverse hacia ese punto por el camino mas optimo que encuentre

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    #endregion

    #region METHODS

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void setNewAgentDestination(Vector3 newDestination)
    {
        //cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }

    #endregion
}
