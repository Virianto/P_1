using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class A_AgentsManager : MonoBehaviour
{
    [SerializeField] GameObject agentPrefab;
    [SerializeField] Transform agentSpawn;
    [SerializeField] Transform humanoidAgentsDestination;


    private void Start()
    {
        StartCoroutine(GenerateNewAgentOPrefab());
    }


    IEnumerator GenerateNewAgentOPrefab()
    {
        A_Agent newAgent = Instantiate(agentPrefab).GetComponent<A_Agent>();

        newAgent.InitializeNewAgent(this, agentSpawn.position, humanoidAgentsDestination.position);
        yield return new WaitForSeconds(1);
        StartCoroutine(GenerateNewAgentOPrefab());
    }




}
