using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     X Ubicar la esfera en una posicion concreta (facilitada desde el Editor)
///     X Introducir aleatoriedad en posicion de origen y en cantidad de esferas
///     X añadir fisicas en el momento de generar cada esfera
///     X Condicionar la generacion a input o a parametros especificos
///     * Gestionar el ciclo de vida de las esferas generadas
/// </summary>

public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 500)]
    int totalSpheresToCreate = 1;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [Space(10)]

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawnSequenceKey = KeyCode.J;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    int currentSequenceIndex = 0;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_BouncingBall> allInstantiatedBallsList = new();
    #endregion

    #region METHODS

    //void Start()
    //{
    //    // Generar una esfera nueva el número de veces que me indica el contador
    //    for (int i = 0; i < totalSpheresToCreate; ++i)
    //    {
    //        GeneratePrefabAtRandomOrigin();
    //    }

    //    // Aplicar cambios a todas las esferas que he generado hasta ahora (recorrer lista)
    //    for (int a = 0; a < allInstantiatedBallsList.Count; ++a)
    //    {
    //        ApplyModificationsToBall(allInstantiatedBallsList[a]);
    //    }
    //}

    void ApplyModificationsToBall(GameObject currentBall)
    {
        currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
        currentBall.name = "Bola " + Random.value.ToString();
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 150);
    }

    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna la posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
        GameObject newBall = GenerateNewPrefab(newRandomPosition);
    }

    void GeneratePrefabAtCustomOrigin()
    {
        GameObject newBall = GenerateNewPrefab(spawnOrigin.position);
    }
    void GeneratePrefabSequentially()
    {
        GameObject newBall = GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);
        currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
    }

    GameObject GenerateNewPrefab(Vector3 newPosition)
    {
        GameObject newBall = Instantiate(ballPrefab);
        allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());
        newBall.GetComponent<C_BouncingBall>().InitializeBall(this,newPosition);
        return newBall;
    }

    private void Update()
    {
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }
        if (Input.GetKeyDown(spawnRandomKey))
        {
            GeneratePrefabAtRandomOrigin();
        }
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GeneratePrefabSequentially();
        }
    }

    #endregion
}

