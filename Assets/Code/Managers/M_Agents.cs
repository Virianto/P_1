using UnityEngine;
using System.Collections;

/// <summary>
/// * Crea instancias del prefab de un agente y las ubica
/// * Los agentes deben tener vida y poder perderla si pisan una trampa
/// * Al morir, cada agente debe notificarlo para que se emitan partículas y sonido/// 
/// * Cuando muere un agente, se crea inmedietamente otro 
/// * En el INIT de cada agente se debe indicar su destino
/// </summary>
public class M_Agents : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject agentPrefab;

    [SerializeField]
    Transform agentsSpawnPoint;

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
        
        yield return new WaitForSeconds(timeBetweenAgents);
        // Llamo de nuevo a la rutina para que se repita infinitas veces
        StartCoroutine(GenerateNewAgentPrefab());        
    }

    #endregion
}
