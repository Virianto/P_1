using System.Collections;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class M_Agents : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    GameObject agentPrefab;

    [SerializeField]
    ParticleSystem agentBloodPS;

    [SerializeField]
    [Range(0.1f, 4)]
    float timeBetweenAgents = 1;

    [SerializeField] 
    Transform spawnedPoint;

    [SerializeField]
    Transform rivalDestinyPoint;
    #endregion


    #region METHODS
    //Vamos a generar los agentes con rutinas así que necesitamos:
    private void Start()
    {
        // 1. Un punto de partida
        StartCoroutine(GenerateNewAgentPrefab());
    }
    
    public IEnumerator GenerateNewAgentPrefab()
    {
        // Genero el Prefab
        C_Agent newAgent = Instantiate(agentPrefab).GetComponent<C_Agent>();

        // Vinculo Prefab y Manager e inicializo el nuevo objeto
        newAgent.InitializeNewAgent(this, spawnedPoint.position, rivalDestinyPoint.position);

        // 2. Una rutina que tenga la capacidad de invocarse a sí misma
        yield return new WaitForSeconds(timeBetweenAgents);

        // Llamo de nuevo a la rutina para q se repita infinitas veces
        StartCoroutine(GenerateNewAgentPrefab());
    }

    public void FinishAgentLifeCycle(C_Agent agentToKill)
    {
        // Coger la posición del agente para lanzar partículas
        Vector3 agentPosition = agentToKill.transform.position;

        agentBloodPS.transform.position = agentPosition;
        agentBloodPS.Emit(30);

        // Reproducir sonido de muerte


        // Destruyo al agente
        Destroy(agentToKill.gameObject);

        // Generar nuevo agente para reemplazar la pérdida
        C_Agent newAgent = Instantiate(agentPrefab).GetComponent<C_Agent>();

        newAgent.InitializeNewAgent(this, spawnedPoint.position, rivalDestinyPoint.position);
    }

    //public void RivalReceiveDamage()
    //{
    //    B_AgentRival liveAgentScript = spawnedRivalInstance.GetComponent<B_AgentRival>();

    //    if (liveAgentScript != null)
    //    {
    //        RivalCanvas.UpdateLifeRivalSlider(liveAgentScript.lifePointsLeft);

    //        //if (liveAgentScript.lifePointsLeft <= 0)
    //        //{
    //        //    
    //        //}
    //    }
    //}
    #endregion
}
