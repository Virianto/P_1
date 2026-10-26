using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    //recibir la orden de dirigirse hacia un punto del mapa
    //va a moerse hacia ese punto por el camino mas optimo qeu encuentre
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
        //cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }
    #endregion

}
