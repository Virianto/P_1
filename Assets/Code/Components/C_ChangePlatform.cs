using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class C_ChangePlatform : MonoBehaviour
{
    #region ATTRUBUTES

    public M_EnemiesManager enemiesManager;

    #endregion



    

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El player está dentro");
            for (int i = 0; i < enemiesManager.allInstantiatedEnemiesList.Count; i++)
            {
                C_SpawnEnemy enemy = enemiesManager.allInstantiatedEnemiesList[i];
                if (enemy != null)
                {
                    NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                    agent.enabled = false;
                }
            }
            enemiesManager.allInstantiatedEnemiesList.Clear();
        }
    }

    #endregion
}
