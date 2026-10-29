using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES
    NavMeshAgent myAgent;
    [SerializeField][Range(-10, 10)] float agentSpeed;
    #endregion

    #region METHODS
    //recibir la orden de dirigirse hacia un punto del mapa
    //moverse hacia ese punto por el camino más óptimo q encuentre
    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        //newDestination *= Time.deltaTime;
        newDestination *= agentSpeed;
        //cambiar destino agente
        myAgent.SetDestination(newDestination);
    }
    #endregion
}
