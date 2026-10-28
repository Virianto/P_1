using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Agentes que van a la posición del player 
/// </summary>
public class B_AngeyAgent : MonoBehaviour
{

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    B_CharacterController player;

   
    


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

    private void OnCollisionEnter(Collision collision)
    {
        player.lifePointsLeft =-1;
        player.totalCoinsCollected = -1;
    }

    public void MoveToFinishLine(Vector3 newFinishLine)
    {
        myAgent.SetDestination(newFinishLine);
    }
    #endregion
}
