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
    ParticleSystem agentBlood_PS;

    [SerializeField]
    Transform agentsSpawnPoint;

    [SerializeField]
    Transform humanoidAgentsDestination;

    [SerializeField]
    B_CharacterController player;

    C_Agent agent;

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

    void Update()
    {
     
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

    public void FinishAgentLifeCycle(C_Agent agentToKill)
    {
        // Coger la posición del agente
        Vector3 agentPosition = agentToKill.transform.position;

        // Lanzar partículas en dicha posición
        agentBlood_PS.transform.position = agentPosition;
        agentBlood_PS.Emit(30);

        // Reproducir un sonido de muerte

        // Destruyo al agente
        Destroy(agentToKill.gameObject);

        // Generar un nuevo agente para reemplazar esta périda        
        C_Agent newAgent = Instantiate(agentPrefab).GetComponent<C_Agent>();

        newAgent.InitializeNewAgent(
            this,
            agentsSpawnPoint.position,
            humanoidAgentsDestination.position
            );
    }

    

    #endregion
}