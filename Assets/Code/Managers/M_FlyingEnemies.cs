using System.Collections;
using UnityEngine;


/// <summary>
/// Generar enemigos en tiempo y lugar aleatorios
/// Gestionar el ciclo de vida de los enemigos
/// </summary>
public class M_FlyingEnemies : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject flyingEnemyPrefab;

    [SerializeField]
    [Range(1, 10)]
    int maxEnemiesInScene = 5;

    [SerializeField]
    [Range(20, 200)]
    float horizontalXRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float verticalYRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float horizontalZRange = 100;

    public float minCreationFrequency = 1;
    public float maxCreationFrequency = 10;

    int currentEnemiesInScene = 0;

    #endregion





    #region METHODS

    /// <summary>
    /// Comenzar la corrutina al empezar el juego
    /// </summary>
    private void Start()
    {
        StartCoroutine(CreateFlyingEnemy());
    }

    /// <summary>
    /// Generar enemigos de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateFlyingEnemy()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(-verticalYRange, verticalYRange), Random.Range(-horizontalZRange, horizontalZRange));

        if (currentEnemiesInScene < maxCreationFrequency)
        {
            GenerateNewFlyingEnemyPrefab(newRandomPosition);
        }

        yield return new WaitForSeconds(Random.Range(minCreationFrequency, maxCreationFrequency));

        StartCoroutine(CreateFlyingEnemy());
    }

    /// <summary>
    /// Crea un enemigo nuevo y lo inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para el nuevo enemigo </param>
    void GenerateNewFlyingEnemyPrefab(Vector3 newPosition)
    {
        // Generamos una instancia del prefab
        B_FlyingEnemy newFlyingEnemy = Instantiate(flyingEnemyPrefab).GetComponent<B_FlyingEnemy>();

        // Inicializamos el script del enemigo
        newFlyingEnemy.InitializeFlyingEnemy(this, newPosition);

        // Aumentamos el contador de enemigos
        currentEnemiesInScene += 1;
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" un enemigo
    /// </summary>
    /// <param name="endFlyingEnemy"> Enemigo que ha solicitado su fin </param>
    public void FinishFlyingEnemyLifeCycle(B_FlyingEnemy endFlyingEnemy)
    {
        // Destruimos el objeto
        Destroy(endFlyingEnemy.gameObject);

        // Reducimos el contador de enemigos
        currentEnemiesInScene -= 1;
    }

    #endregion
}