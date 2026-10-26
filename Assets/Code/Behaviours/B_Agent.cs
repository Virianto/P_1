using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES

    //recibir la orden de dirigirse hacia un punto del mapa
    //va amoverse hacia ese punto por el camino mas optimo que encuentre

    NavMeshAgent myAgent;


    #endregion
    #region METHODS 

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    public void SetNewAgentDestination(Vector3 NewDestination)

    {
        // cambia del destino de mi agente
        myAgent.SetDestination(NewDestination);
    }


    #endregion
}
