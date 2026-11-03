using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase va a generar agentes que al morir emitan partículas y crear otro nuevo si muere.
/// Dependiendo del agente tendrá un propósito u otro.
/// </summary>
public class M_AgentsManager : MonoBehaviour
{

    #region ATTRIBUTES


    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 30)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 30)]
    float horizontalZRange = 2;

    Vector3 targetPoint = Vector3.zero;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject humanoidAgent;
    [SerializeField]
    GameObject birdAgent;
    [SerializeField]
    GameObject moleAgent;

    public B_CharacterController player;
    

    List<C_Agent> allInstantiatedHumanoidAgents = new();
    List<C_Agent> allInstantiatedBirdAgents = new();

    #endregion


    #region METHODS

    private void Start()
    {
        StartCoroutine(HumanoidAgentSpawn());
        StartCoroutine(BirdAgentSpawn());
    }

    private void Update()
    {
        MoveAgentToPlayer();
    }

    void GenerateNewHumanoidAgentPrefab(Vector3 newPosition)
    {

        C_Agent newAgent = Instantiate(humanoidAgent).GetComponent<C_Agent>();
        allInstantiatedHumanoidAgents.Add(newAgent);
        newAgent.InitializeAgent(this, newPosition);
        
    }
    void GenerateNewBirdAgentPrefab(Vector3 newPosition)
    {
        C_Agent newAgent = Instantiate(birdAgent).GetComponent<C_Agent>();
        allInstantiatedBirdAgents.Add(newAgent);
        newAgent.InitializeAgent(this, newPosition);

    }


    IEnumerator HumanoidAgentSpawn()
    {
        
        Vector3 newPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewHumanoidAgentPrefab(newPosition);
        yield return new WaitForSeconds(50000);
        StartCoroutine(HumanoidAgentSpawn());

    }


    IEnumerator BirdAgentSpawn()
    {

        Vector3 newPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewBirdAgentPrefab(newPosition);
        yield return new WaitForSeconds(500000);
        StartCoroutine(BirdAgentSpawn());

    }

    void MoveAgentToPlayer()
    {
        for (int a = 0; a < allInstantiatedHumanoidAgents.Count; ++a)
        {
            targetPoint = player.transform.position;
            allInstantiatedHumanoidAgents[a].MoveToPlayerDestination(targetPoint);
        }
        for (int a = 0; a < allInstantiatedBirdAgents.Count; ++a)
        {
            targetPoint = player.transform.position;
            allInstantiatedBirdAgents[a].MoveToPlayerDestination(targetPoint);
        }
    }

    public void KillAgent(C_Agent agent)
    {
        if (agent.isItHumanoid == true)
        {
            allInstantiatedHumanoidAgents.Remove(agent);
            Destroy(agent.gameObject);
            Vector3 newPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewHumanoidAgentPrefab(newPosition);
        }
        if (agent.isItBird == true)
        {
            allInstantiatedBirdAgents.Remove(agent);

            Destroy(agent.gameObject);
        }

    }
    #endregion
}
