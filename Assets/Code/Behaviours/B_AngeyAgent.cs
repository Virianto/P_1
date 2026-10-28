using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Agentes que van a la posición del player 
/// </summary>
public class B_AngeyAgent : MonoBehaviour
{

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    public B_CharacterController player;

    public bool isItHumanoid = false;
    public bool isItBird = false;

   
    


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

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<B_CharacterController>();
        if (isItBird == true)
        {
            player.TakeDamage(1);
        }
        if (isItHumanoid == true) 
        {
            if (player.totalCoinsCollected > 0)
            {
                player.EarnMoney(-1);
            }
            
        }
        

        
    }

    public void MoveToFinishLine(Vector3 newFinishLine)
    {
        myAgent.SetDestination(newFinishLine);
    }
    #endregion
}
