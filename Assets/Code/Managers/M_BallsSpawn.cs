using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Esta clase se encarga de generar esferas en escena siguiendo algunas condiciones.
///     * Ubicar la efera en na posicion concreta, facilitada desde el Editor.       
///     * Introducir aleatoriedad en una posición concreta (facilitada desde el Editor)
///     * Añadir físicas en el momento de generar cada esfera.
///     * Condicionar la generación a input o parámetros específicos.   
///     * Gestionar el ciclo de vida de las esferas generadas.
/// </summary>
public class M_BallsSpawn : MonoBehaviour
    {
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(0, 100)]
    int sphereToCreate = 1;

    //añadir una variable q permita definir un rango horizontal
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [Space(10)]

    [SerializeField] KeyCode spawnAtOriginKey = KeyCode.G;
    [SerializeField] KeyCode spawnRandomnKey = KeyCode.H;
    [SerializeField] KeyCode spawnSequenceKey = KeyCode.J;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnOrigin;

    [SerializeField] List<Transform> allSequencePointsList;
    int currentSequenceIndex = 0;

    List<GameObject> allInstantiatedBallsList = new();
    //List<C_BouncingBall>


    #endregion

    #region METHODS
    //void Start()
    //{
    //    //generar una esfera nueva el num de veces q me indica el contador
    //    for (int i = 0; i < sphereToCreate; i++)
    //    {
    //        //GeneratePrefabAtCustomOrigin();
    //        GeneratePrefabAtRandomOrigin();
    //    }

    //    for (int i = 0; i < allInstantiatedBallsList.Count; i++)
    //    {
    //        ApplyModificationsToBall(allInstantiatedBallsList[i]);
    //    }
    //}

    void Update()
    {
        //detectar una tecla para generar una esfera en el spawnOrigin
        if(Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }

        //detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomnKey))
        {
            GeneratePrefabAtRandomOrigin();
        }

        // detectar otra tecla para generar esferas de forma ciclica o sequencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GeneratePrefabSequentially();
        }
    }

    //void ApplyModificationsToBall(GameObject currentBall)
    //{
    //    currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
    //    currentBall.name="Bola " + Random.value.ToString();
    //    currentBall.GetComponent<Rigidbody>().mass = Random.Range(0.1f, 5f);
    //}

    GameObject GeneratePrefab(Vector3 newOrigin)
    {
        //generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //ubicar la instancia en el origen q le corresponda
        newBall.transform.position = newOrigin;

        allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());

        newBall.GetComponent<C_BouncingBall>().InitializeBall(this);

        return newBall;
    }

    void GeneratePrefabAtRandomOrigin()
    {
        //generar uan nueva posición aleatoria
        Vector3 newRandomPosition = new Vector3
            (Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
        GameObject newBall = GeneratePrefab(newRandomPosition);

    }

    void GeneratePrefabAtCustomOrigin()
    {
        GameObject newBall = GeneratePrefab(spawnOrigin.position);
    }

    void GeneratePrefabSequentially()
    {
        GameObject newBall = GeneratePrefab(allSequencePointsList[currentSequenceIndex].position);

        //actualizar el indice para la siguiente vez
        currentSequenceIndex=(currentSequenceIndex + 1) % allSequencePointsList.Count;
    }

    #endregion
}
