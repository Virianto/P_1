using System.Collections;
using UnityEngine;

/// <summary>
/// El Manager se va a encargar de generar enemigos de forma aleatoria en el mapa
/// Se generaran cada cierto tiempo
/// En una zona de generación
/// </summary>
public class M_EnemiesManager : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("EDITABLE VALUES")]

    [Space(10)]
    [SerializeField]
    [Range(1, 100)]
    int maxNumberOfEnemies = 10;
    [SerializeField]
    [Range(1, 10)]
    float timeBetweenSpawns = 5;
  

    
    [Space(5)]

    [SerializeField]
    [Range(1, 300)]
    float horizontalXRange = 10;

    [SerializeField]
    [Range(1, 300)]
    float horizontalZRange = 10;

    [SerializeField]
    [Range(1, 300)]
    float verticalRange = 10;


    int numberOfEnemies = 0;


    [Header("EXTERNAL REFERENCES")]
    [Space(10)]

    [SerializeField]
    GameObject enemyPrefab;
    #endregion


    #region METHODS

    void Start()
    {
     StartCoroutine(EnemySpawnTimeCycle());   
    }

    void GenerateNewPrefab()
    {
        B_Enemy newEnemy = Instantiate(enemyPrefab).GetComponent<B_Enemy>();
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(0, verticalRange), Random.Range(-horizontalZRange, horizontalZRange));
        newEnemy.InitializeEnemy(this, newRandomPosition);
    }


    IEnumerator EnemySpawnTimeCycle()
    {
        GenerateNewPrefab();
        numberOfEnemies++;
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (numberOfEnemies < maxNumberOfEnemies) 
        {
            StartCoroutine(EnemySpawnTimeCycle());
        }
    }

    public void FinishEnemyLifeCycle(B_Enemy enemy)
    {
        Destroy(enemy.gameObject);
        numberOfEnemies--;
    }
    #endregion
}
