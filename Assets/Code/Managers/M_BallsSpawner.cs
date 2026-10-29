using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// Esta clase se ocupa de generar esferas en escena seguiendo algunas condiciones
/// x Ubicar la esfera en una posición concreta (facilitada desde el editor)
/// x Introducir aleatoriedad en posición de orgen y en cantidad de esferas
/// x Añadir físicas en el momento de generar cada esfera
/// x Condicionar la generación a input o a parámetros específicos
/// * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawner : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    // Añadir una variable que me permita definir un rango horizontal (x)
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    // Añadir una variable que me permita definir un rango de profundidad (z)
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


    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_BouncingBall> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    #endregion



    #region METHODS
    // Generar una esfera en escena

    void Start()
    {
        // Generar una esfera nueva el número de veces que me indica el contador
        for(int i = 0; i < totalSpheresToCreate; ++i)
        {
            //GeneratePrefabAtRandomOrigin();
        }

        // Aplicar cambios a todas las esferas que he generado hasta ahroa 
        for(int a = 0; a < allInstantiatedBallsList.Count; ++a)
        {

            //ApplyModificationsToBall(allInstantiatedBallsList[a]);

        }
    }

    void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }

        // Detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey))
        {
            GeneratePrefabAtRandomOrigin();
        }

        // Detectar OTRA tecla para generar esferas de forma cíclica/secuencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GeneratePrefabSequentially();
        }
    }

    void ApplyModificationsToBall(GameObject currentBall)
    {

        currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
        currentBall.name = "Bola" + Random.value.ToString();
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(300, Vector3.zero, 150);
    }

    void GeneratePrefabSequentially()
    {
        // Generar una instancia nueva del prefab

        GameObject newBall = GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);

        //GameObject newBall = Instantiate(ballPrefab);
        //newBall.name = "NuevaEsferaSecuencial";
        //newBall.tag = "Coin";
        //newBall.layer = 12;

        // Ubicar la instancia en el origen que le corresponda de la secuencia
        //newBall.transform.position = allSequencePointsList[currentSequenceIndex].position;

        // Actualizar el índice de la secuencia para la sigiuente vez (asegurando ciclo)
        //++currentSequenceIndex;   No vuelve al inicio de la lista y da error
        currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;    // Vuelve al inicio de la lista, repitiéndose
    }

    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna la posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {

        // Generar nueva posición aleatoria usando las variables de rango
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

        // Generar una instancia del prefab
        GameObject newBall = GenerateNewPrefab(newRandomPosition);

        //GameObject newBall = Instantiate(ballPrefab);
        //newBall.name = "NuevaEsferaAleatoria";
        //newBall.tag = "Coin";
        //newBall.layer = 12;


        // Ubicar el prefab en la posición aleatoria
        //newBall.transform.position = newRandomPosition;


        // Añadir esta esfera a la lista de objetos generados
        //allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());
    }

    void GeneratePrefabAtCustomOrigin()
    {

        // Generar una instancia del prefab

        GameObject newBall = GenerateNewPrefab(spawnOrigin.position);
        //newBall.name = "NuevaEsferaTemporal";
        //newBall.tag = "Coin";
        //newBall.layer = 12;

        // Ubicar esfera en la posición de mi transform de referencia
        //newBall.transform.position = spawnOrigin.position;

        // Añadir esta esfera a la lista de objetos generados
        //allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());


    }

    // El método GameObject siempre debe devolver un GameObject
    GameObject GenerateNewPrefab(Vector3 newPosition)
    {
        GameObject newBall = Instantiate(ballPrefab);

        newBall.transform.position = newPosition;

        allInstantiatedBallsList.Add(newBall.GetComponent<C_BouncingBall>());

        newBall.GetComponent<C_BouncingBall>().InitializeBall(this, newPosition);    // "this" es referencia a ESTA clase (en escena)

        return newBall;
    }

    #endregion
}