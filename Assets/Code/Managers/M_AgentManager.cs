using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class M_AgentManager : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] GameObject agentPrefab;
    [SerializeField] Transform spawnOrigin;
    [SerializeField] Transform agentDestination;
    #endregion

    #region METHODS
    void Start()
    {
        SpawnAgent();
    }

    public void KillAgent(B_NewAgent agent)
    {
        Destroy(agent.gameObject);
        StartCoroutine(Respawn());
    }

    public void SpawnAgent()
    {
        B_NewAgent newAgent = Instantiate(agentPrefab).GetComponent<B_NewAgent>();
        newAgent.InitializeAgent(spawnOrigin, agentDestination, this);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        SpawnAgent();
    }
    #endregion
}
