using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_SpawnAgentsManagers : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    B_CharacterController player;

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

    #endregion
}

