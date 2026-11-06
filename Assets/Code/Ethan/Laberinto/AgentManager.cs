using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    [SerializeField] GameObject hurtAgentPrefab;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnOrigin;
    NewHurtAgent agentHurt;
    KeyCode spawnKey = KeyCode.T;
    //List<NewHurtAgent> hurtAgentList = new();
    void Start()
    {
        
    }

    void Update()
    {
        agentHurt = GetComponent<NewHurtAgent>();
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnKey))
        {
            GenerateNewPrefab();
        }
        if (agentHurt.lifePointsLeft == 0)
        {
            Destroy(agentHurt.gameObject);
        }
    }

    void GenerateNewPrefab()
    {

        // 1. Spawn directly at the spawnOrigin position and rotation
        GameObject spawnedObj = Instantiate(hurtAgentPrefab, spawnOrigin.position, spawnOrigin.rotation);

        // 2. Initialize the agent custom script
        NewHurtAgent newHurt = spawnedObj.GetComponent<NewHurtAgent>();
        newHurt.InitializeHurtAgent(this, spawnOrigin.position, player);

        //allInstantiatedBallsList.Add(newBall);
        //newBall.InitializeBall(this, newPosition, Random.value * 5);
    }
}
