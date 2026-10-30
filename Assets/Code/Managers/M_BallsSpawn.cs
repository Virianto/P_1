using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Generar esferas en escena siguiendo ciertas condiciones
///     * Ubicar una esfera en una posición concreta
///     * Introducir aleatoriedad en la posición de origen y en la cantidad de esferas
///     * Añadir físicas en el momento de generar cada esfera
///     * Condicionar la generación a Input o a parámetros específicos
///     * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("Valores editables")]

    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    // Añadir una variable que permita difinir un rango en el eje x
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 7.5f;

    // Añadir una variable que permita definir un rango en el eje z
    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 7.5f;

    [Space(10)]

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawnSequenceKey = KeyCode.J;


    [Header("Referencias externas")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_BouncingBall> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    #endregion





    #region METHODS

    private void Start()
    {
        // Generar una instancia (copia) del prefab
        // GameObject newBall = Instantiate(ballPrefab);

        // Podemos cambiarle el nombre
        // newBall.name = "nuevaEsferaTemporal";

        // Podemos cambiarle el tag (tiene que existir en Unity)
        // newBall.tag = "Coin";

        // Podemos cambiarle el layer (tiene que existir en Unity)
        // newBall.layer = 6;

        // Ubicar una esfera en una posición concreta
        // newBall.transform.position = spawnOrigin.position;

        // Generar una esfera nueva el número de veces que me indica el contador
        // for (int i = 0; i < totalSpheresToCreate; ++i)
        // {
            // GeneratePrefabAtRandomOrigin();

            // GeneratePrefabAtCustomOrigin();
        // }

        // Aplicar cambios a todas las esferas que se han generado hasta ahora
        // for (int a = 0; a < allInstantiatedBallsList.Count; ++a)
        // {
            // ApplyModificationsToBall(allInstantiatedBallsList[a]);
        // }
    }

    private void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
            
        }
        // Detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefab(newRandomPosition);
        }
        // Detectar otra tecla diferente para generar esferas de forma secuencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }

    void ApplyModificationsToBall(GameObject currentBall)
    {
        // Modificar el color aleatoriamente
        // currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();

        // Modificar el nombre aleatoriamente
        // currentBall.name = "Bola " + Random.value.ToString();

        // Modificar la fuerza del movimiento inicial
        // currentBall.GetComponent<Rigidbody>().AddExplosionForce(300, Vector3.zero, 150);
    }

    void GeneratePrefabSequentially()
    {
        // Generar una instancia nueva del prefab
        // GameObject newBall = Instantiate(ballPrefab);
        // GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);

        // Ubicarla instancia en el origen que le corresponda de la secuencia
        // newBall.transform.position = allSequencePointsList[currentSequenceIndex].position;

        // Actualizar el índice de la secuencia para la vez siguiente
        // currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;

        // Añadir la esfera a la lista de objetos generados
        // allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());
    }

    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna una posición aleatoria
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {
        // Generar una posición aleatoria
        // Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

        // Generar una instancia del prefab
        // GameObject newBall = Instantiate(ballPrefab);
        // GenerateNewPrefab(newRandomPosition);

        // Ubicar el prefab en una posición aleatoria
        // newBall.transform.position = newRandomPosition;

        // Añadir la esfera a la lista de objetos generados
        // allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());
    }

    /// <summary>
    /// Crea una instancia del prefab y le asigna una posición preestablecida
    /// </summary>
    void GeneratePrefabAtCustomOrigin()
    {
        // Generar una instancia (copia) del prefab
        // GameObject newBall = Instantiate(ballPrefab);
        // GenerateNewPrefab(spawnOrigin.position);

        // Ubicar una esfera en una posición concreta
        // newBall.transform.position = spawnOrigin.position;

        // Añadir la esfera a la lista de objetos generados
        // allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());
    }

    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para la nueva esfera </param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();

        // Añadir la esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);
        newBall.InitializeBall(this, newPosition, Random.value * 5);
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" una bola
    /// </summary>
    /// <param name="ball"> Bola que ha solicitado su fin </param>
    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        // Eliminamos la bola de la lista
        allInstantiatedBallsList.Remove(ball);

        // Destruimos el objeto
        Destroy(ball.gameObject);
    }

    #endregion
}