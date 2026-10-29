using System;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// Esta clase se ocupa de generar esferas en escena seguiendo algunas condiciones
/// x Ubicar la esfera en una posición concreta (facilitada desde el editor)
/// x Introducir aleatoriedad en posición de orgen y en cantidad de esferas
/// * Añadir físicas en el momento de generar cada esfera
/// * Gestionar el ciloc de vida de las esferas generadas
/// </summary>
public class M_BallsSpawner : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalApheresToCreate = 1;

    // Añadir una variable que me permita definir un rango horizontal (x)
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    // Añadir una variable que me permita definir un rango de profundidad (z)
    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;


    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    #endregion



    #region METHODS
    // Generar una esfera en escena

    void Start()
    {
        // Generar una esfera nueva el número de veces que me indica el contador
        for(int i = 0; i < totalApheresToCreate; ++i)
        {
            GeneratePrefabAtRandomOrigin();
        }

    }

    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna la posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {

        // Generar nueva posición aleatoria usando las variables de rango
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        newBall.name = "NuevaEsferaTemporal";
        newBall.tag = "Coin";
        newBall.layer = 12;

        // Ubicar el prefab en la posición aleatoria
        newBall.transform.position = newRandomPosition;

    }

    void GeneratePrefabAtCustomOrigin()
    {

        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        newBall.name = "NuevaEsferaTemporal";
        newBall.tag = "Coin";
        newBall.layer = 12;

        // Ubicar esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin.position;


    }

    #endregion
}