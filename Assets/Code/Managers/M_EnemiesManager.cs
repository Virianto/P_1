using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_EnemiesManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 30)]
    float horizontalXRange = 15;

    [SerializeField]
    [Range(1, 30)]
    float horizontalZRange = 15;

    [SerializeField]
    GameObject enemyPrefab;

    List<C_SpawnEnemy> allInstantiatedEnemiesList = new();

    public float minCreationFrequency = 1;
    public float maxCreationFrequency = 10;

    Vector3 destinationPoint = Vector3.zero;

    public B_CharacterController player;

    #endregion





    #region METHODS

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private void Update()
    {
        destinationPoint = player.transform.position;

        for (int a = 0; a < allInstantiatedEnemiesList.Count; ++a)
        {
            allInstantiatedEnemiesList[a].SetNewAgentDestination(destinationPoint);
        }
    }

    void GenerateNewEnemyPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_SpawnEnemy newEnemy = Instantiate(enemyPrefab).GetComponent<C_SpawnEnemy>();

        // Añadir el enemigo a la lista de objetos generados
        allInstantiatedEnemiesList.Add(newEnemy);
        newEnemy.InitializeEnemy(this, newPosition);
    }

    /// <summary>
    /// Generar enemigos de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateEnemy()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewEnemyPrefab(newRandomPosition);

        yield return new WaitForSeconds(Random.Range(minCreationFrequency, maxCreationFrequency));
        StartCoroutine(CreateEnemy());
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" a un enemigo
    /// </summary>
    /// <param name="enemy"> Enemigo que ha solicitado su fin </param>
    public void FinishEnemyLifeCycle(C_SpawnEnemy enemy)
    {
        // Eliminamos al enemigo de la lista
        allInstantiatedEnemiesList.Remove(enemy);

        // Destruimos el objeto
        Destroy(enemy.gameObject);
    }

    #endregion
}
