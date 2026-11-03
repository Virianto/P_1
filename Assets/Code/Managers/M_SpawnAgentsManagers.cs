using System.Collections.Generic;
using UnityEngine;
using static B_Agent;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_SpawnAgentsManagers : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    B_CharacterController player;

    [SerializeField]
    ParticleSystem agentBlood_PS;

    [SerializeField]
    GameObject humanoidAgentPrefab;

    [SerializeField]
    GameObject flyingAgentPrefab;

    [SerializeField]
    GameObject diggerAgentPrefab;

    int currentSequenceIndex = 0;

    [SerializeField]
    List<Transform> allSpawnsPointsList = new();

    List<B_Agent> allInstantiatedAgentsLists = new();

    #endregion
    #region METHODS

    void GenerateHumanoidAgentPrefab(Vector3 newPosition)
    {
        B_Agent newAgent = Instantiate(humanoidAgentPrefab).GetComponent<B_Agent>();
        allInstantiatedAgentsLists.Add(newAgent);
        newAgent.InitializeAgent(this, newPosition, player);
    }

    void GenerateFlyingAgentPrefab(Vector3 newPosition)
    {
        B_Agent newAgent = Instantiate(flyingAgentPrefab).GetComponent<B_Agent>();
        allInstantiatedAgentsLists.Add(newAgent);
        newAgent.InitializeAgent(this, newPosition, player);
    }

    void GenerateDiggerAgentPrefab(Vector3 newPosition)
    {
        B_Agent newAgent = Instantiate(diggerAgentPrefab).GetComponent<B_Agent>();
        allInstantiatedAgentsLists.Add(newAgent);
        newAgent.InitializeAgent(this, newPosition, player);
    }

    private Vector3 GenerateRandomPosition()
    {
        currentSequenceIndex = Random.Range(0, allSpawnsPointsList.Count);
        Vector3 spawnPosition = allSpawnsPointsList[currentSequenceIndex].position;
        return spawnPosition;
    }

    private void Start()
    {
        Vector3 spawnPositionHumanoidAgent = GenerateRandomPosition();
        GenerateHumanoidAgentPrefab(spawnPositionHumanoidAgent);

        Vector3 spawnPositionFlyingAgent = GenerateRandomPosition();
        GenerateFlyingAgentPrefab(spawnPositionFlyingAgent);

        //Vector3 spawnPositionDiggerAgent = GenerateRandomPosition();
        //GenerateDiggerAgentPrefab(spawnPositionDiggerAgent);
    }

    public void FinishAgentLifeCycle(B_Agent agentToKill)
    {
        // Coger la posición del agente
        Vector3 agentPosition = agentToKill.transform.position;

        // Lanzar partículas en dicha posición
        agentBlood_PS.transform.position = agentPosition;
        agentBlood_PS.Emit(30);

        // Reproducir un sonido de muerte

        // Destruyo al agente
        allInstantiatedAgentsLists.Remove(agentToKill);
        Destroy(agentToKill.gameObject);

        // Generar un nuevo agente para reemplazar esta périda        
        if (agentToKill.GetComponent<AgentType>() == AgentType.Humanoid)
        {
            GenerateHumanoidAgentPrefab(GenerateRandomPosition());
        }
        if (agentToKill.GetComponent<AgentType>() == AgentType.Bird)
        {
            GenerateFlyingAgentPrefab(GenerateRandomPosition());
        }
        if (agentToKill.GetComponent<AgentType>() == AgentType.Digger)
        {
            GenerateDiggerAgentPrefab(GenerateRandomPosition());
        }
    }

    #endregion
}

