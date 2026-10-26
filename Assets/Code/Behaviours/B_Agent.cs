using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    #region ATTRIBUTES

    NavMeshAgent myAgent;

    #endregion

    #region METHODS
    //Recibir orden de dirigirse a un punto
    //Va a moverse por el camino más optimo para llegar

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        //Cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }
    #endregion
}
