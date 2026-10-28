using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    //Recibir la orden de moverse hacia un punto del mapa
    //y va a moverse hacia ese punto por el camino mas optimo que encuentre

    #region ATTRIBUTE
    

    [SerializeField]
    GameObject player;
    NavMeshAgent myAgent;

    int trapDamage = 1;

    int coinsLost = 1;

    float trapFrequencyDamage = 1;

    private bool playerIsInsideAreaAgent0 = false;

    bool playerIsInsideAreaAgent1 = false;

    float trapFrequency = 1;


    public enum AgentType
    {
        Humanoid,
        Bird,
        Mole
    }

    [SerializeField]
    AgentType agentType;

    #endregion

    #region METHODS

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agentType == AgentType.Humanoid || agentType == AgentType.Bird)
        {
            myAgent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (agentType == AgentType.Humanoid)
        {
            playerIsInsideAreaAgent0 = true;
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
            Debug.Log("ESTOY DAÑANDO AL JUGADOR");
            
        }
        if (agentType == AgentType.Bird)
        {
            Debug.Log("Etoy quitando monedas");
            playerIsInsideAreaAgent1 = true;
            StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (agentType == AgentType.Humanoid)
        {
            playerIsInsideAreaAgent0 = false;
            Debug.Log("e dejado de dañar al jugador");
        }
        if (agentType == AgentType.Bird)
        {
            playerIsInsideAreaAgent1 = false;
        }
    }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        if (playerIsInsideAreaAgent0)
        {
            StartCoroutine(HurtPlayer(player));
        }
    }

    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {

        player.EarnMoney(-coinsLost);

        yield return new WaitForSeconds(trapFrequency);

        if (playerIsInsideAreaAgent1)
        {
            StartCoroutine(StealCoinsToPlayer(player));
        }
    }

}


    #endregion

