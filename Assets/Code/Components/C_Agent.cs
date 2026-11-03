
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Esta clase se encarga de generar un tipo de agente con una vida determinada
/// </summary>
public class C_Agent : MonoBehaviour
{

    #region ATTRIBUTES

    public bool isItHumanoid = false;

    public bool isItBird = false;

    public bool isItMole = false;

    //public B_CharacterController player;
    public M_AgentsManager agentsManager;
    public B_CharacterController player;
    public int totalAgentLifePoints = 3;
    NavMeshAgent myAgent;



    #endregion


    #region METHODS

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (totalAgentLifePoints == 0)
        {
            agentsManager.KillAgent(this);
        }
    }
    public void InitializeAgent(M_AgentsManager manager, Vector3 newPosition)
    {
        agentsManager = manager;
        transform.position = newPosition;
    }


    public void MoveToPlayerDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }
    public void TakeDamage(int damageAmount)
    {
        //Modificar la cantidad de vida al jugador
        totalAgentLifePoints -= damageAmount;
        Mathf.Clamp(totalAgentLifePoints, 0, 3);
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


    //void OnCollisionEnter(Collision collision)
    //{
    //    player = collision.GetContact();
    //    if (isItBird == true)
    //    {
    //        player.TakeDamage(1);
    //    }
    //    if (isItHumanoid == true)
    //    {
    //        if (player.totalCoinsCollected > 0)
    //        {
    //            player.EarnMoney(-1);
    //        }

    //    }
    //}


    #endregion
}
