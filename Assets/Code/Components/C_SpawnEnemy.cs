using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class C_SpawnEnemy : MonoBehaviour
{
    #region ATTRIBUTES

    M_EnemiesManager MyManager;

    public float minLifeTime = 5;
    public float maxLifeTime = 15;

    NavMeshAgent myAgent;

    #endregion





    #region METHODS

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        // Cambiar el destino del Agente
        myAgent.SetDestination(newDestination);
    }

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeEnemy(M_EnemiesManager manager, Vector3 newPosition)
    {
        MyManager = manager;
        transform.position = newPosition;

        StartCoroutine(FinishEnemyLifeCycle());
    }

    /// <summary>
    /// Gestionar el ciclo de vida de los enemigos
    /// </summary>
    IEnumerator FinishEnemyLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishEnemyLifeCycle(this);
    }

    #endregion
}
