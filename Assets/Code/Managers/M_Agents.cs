using UnityEngine;
using System.Collections;

/// <summary>
/// * Crea instancias del prefab de un agente y las ubica
/// * Al morir, cada agente debe notificarlo para que se emitan partículas y sonido
/// * Cuando muere un agente, se crea inmedietamente otro
/// </summary>
public class M_Agents : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject agentPrefab;

    [SerializeField]
    Transform agentsSpawnPoint;

    [SerializeField]
    Transform humanoidAgentsDestination;

    [SerializeField]
    [Range(0.1f, 4)]
    float timeBetweenAgents = 1;

    #endregion

    #region METHODS

    // Vamos a generar los agentes mediante rutinas, así que necesitamos 2 cosas:
      
    void Start()
    {        
        StartCoroutine(GenerateNewAgentPrefab());
    }

    IEnumerator GenerateNewAgentPrefab()
    {
        // Genero el prefab
        C_Agent newAgent = Instantiate(agentPrefab).GetComponent<C_Agent>();

        //Vinculo prefab y manager. E inicializo el nuevo objeto
        newAgent.InitializeNewAgent(
            this, 
            agentsSpawnPoint.position, 
            humanoidAgentsDestination.position
            );
        
        yield return new WaitForSeconds(timeBetweenAgents);

        // Llamo de nuevo a la rutina para que se repita infinitas veces
        StartCoroutine(GenerateNewAgentPrefab());        
    }

    #endregion
}
