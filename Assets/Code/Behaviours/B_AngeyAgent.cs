using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Agentes que van a la posición del player 
/// </summary>
public class B_AngeyAgent : MonoBehaviour
{

    #region ATTRIBUTES

    NavMeshAgent myAgent;
    


    #endregion


    #region METHODS
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    
    }


    public void MoveToPlayerDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }
    #endregion
}
