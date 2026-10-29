using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///  X Ubicar la esfera en una posición concreta facilitada desde el editor
///  X Introducir aleatoriedad en posición de origen y en cantidad de esferas
///  X Añadir físicas en el momento de generar cada esfera
///  X Condicionar la generación a input o a parámetros específicos
///  * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{
    [Header("VALORES EDITABLES")]
    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    // Variable q me permita definir un rango horizontal (X)
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    // Variable q me permita definir un rango de profundidad (Z)
    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    // Fuerza de la explosión
    [SerializeField]
    [Range(50, 1000)]
    int forzeBall = 100;

    [Space(10)]

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawSequenceKey = KeyCode.J;


    [Header ("REFERENCIAS EXTERNAS")]
    #region ATTRIBUTES
    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<GameObject> allInstantiatedBallList = new();

    int currentSequenceIndex = 0;

    #endregion


    #region METHODS

    // Generar una esfera en escena
    private void Start()
    {
        // Generar una esfera nueva el número de veces q me indica el contador
        for (int i = 0; i < totalSpheresToCreate; ++i)
        {
            //GeneratePrefabAtRandomOrigin();
        }

        // Aplicar los cambios a todas las esferas q he generado hasta ahora
        for (int a = 0; a < allInstantiatedBallList.Count; ++a)
        {
            ApplyModificationsToBall(allInstantiatedBallList[a]);
        }
    }

    private void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }
        // Detectar una tecla DIFERENTE para generar una oleada de esferas aleatoria
        if (Input.GetKeyDown(spawnRandomKey))
        {
            GeneratePrefabAtRandomOrigin();
        }
        // Detectar OTRA tecla para generar esferas de forma cíclica/secuencial
        if (Input.GetKeyDown(spawSequenceKey))
        {
            GeneratePrefabSequentially();
        }
    }


    void ApplyModificationsToBall(GameObject currentBall)
    {
        currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
        currentBall.name = "Bola" + Random.value.ToString();
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(forzeBall, Vector3.zero,150);
    }

    void GeneratePrefabSequentially()
    {
        // Generar una instancia nueva del prefab
        GameObject newBall = Instantiate(ballPrefab);

        // Ubicar la ionstancia en el origen q le corresonda de la secuencia
        newBall.transform.position = allSequencePointsList[currentSequenceIndex].position;

        // Actualizar el índice de la secuencia para la siguiente vez
        currentSequenceIndex = (currentSequenceIndex +1) % allSequencePointsList.Count;
    }


    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna una posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {
        // Generar una nueva posición aleatoria
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
        
        // Generar una instacia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        // Ubicar el prefab en la posición aleatoria
        newBall.transform.position = newRandomPosition;

        // Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallList.Add(newBall);

    }

    void GeneratePrefabAtCustomOrigin()
    {
        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);
        //newBall.name = "NuevaEsferaTemporal";
        //newBall.tag = "Coin";
        //newBall.layer = 6;

        // Ubicar la esfera en una posición concreta facilitada desde el editor
        newBall.transform.position = spawnOrigin.position;

        allInstantiatedBallList.Add(newBall);
    }

    #endregion
}
