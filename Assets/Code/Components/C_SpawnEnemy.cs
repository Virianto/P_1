using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class C_SpawnEnemy : MonoBehaviour
{
    #region ATTRIBUTES

    M_EnemiesManager myManager;

    public float minLifeTime = 20;
    public float maxLifeTime = 30;

    public int lifePointsLeft = 1;

    NavMeshAgent myEnemy;

    #endregion





    #region METHODS

    public void SetNewEnemyDestination(Vector3 newDestination)
    {
        // Cambiar el destino del Agente
        myEnemy.SetDestination(newDestination);
    }

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeEnemy(M_EnemiesManager manager, Vector3 newPosition)
    {
        myEnemy = GetComponent<NavMeshAgent>();

        myManager = manager;
        transform.position = newPosition;

        StartCoroutine(FinishEnemyLifeCycle());
    }

    /// <summary>
    /// Gestionar el ciclo de vida de los enemigos
    /// </summary>
    IEnumerator FinishEnemyLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en Initialize (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en Initialize (donde hemos metido la corutina)

        myManager.FinishEnemyLifeCycle(this);
    }

    public void TakeDamage(int damageAmount)
    {
        // Modificar la cantidad de vida del enemigo
        lifePointsLeft = Mathf.Clamp(lifePointsLeft - damageAmount, 0, 1);

        if (lifePointsLeft <= 0)
        {
            myManager.FinishEnemyLifeCycle(this);
        }
    }

    #endregion

}