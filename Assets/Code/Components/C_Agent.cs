using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Esta clase se encarga de generar un tipo de agente con una vida determinada
/// </summary>
public class C_Agent : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    Image lifeBarImage;

    public bool isItHumanoid = false;

    public bool isItBird = false;

    public bool isItMole = false;

    M_AgentsManager agentsManager;
    B_CharacterController player;
    NavMeshAgent myAgent;

    int currentLifePoints = 3;
    int maxLifePoints = 3;
    



    #endregion


    #region METHODS

    private void Awake()
    {
        
    }


    private void Update()
    {
     
    }
    public void InitializeAgent(M_AgentsManager manager, Vector3 newPosition)
    {

       myAgent = GetComponent<NavMeshAgent>();
       agentsManager = manager;
       myAgent.SetDestination(newPosition); 

    }


    public void MoveToPlayerDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }
    public void ModifyAgentLifePoints(int damageAmount)
    {
        //Modificar la cantidad de vida al jugador
        currentLifePoints -= damageAmount;

        float newFillAmount = (float)currentLifePoints / maxLifePoints;
        lifeBarImage.fillAmount = newFillAmount;
        
        if(currentLifePoints <= 0)
        {
            agentsManager.KillAgent(this);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    player = other.GetComponent<B_CharacterController>();
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


    void OnCollisionEnter(Collision other)
    {
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


    #endregion
}
