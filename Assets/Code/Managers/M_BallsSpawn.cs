using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
/// * Ubicar la esfera en una posición concreta (facilitada desde el editor)
/// * Introducir aleatoriedad en posición de origen y en cantidad de esferas
/// * Añadir físicas en el momento de generar cada esfera
/// * Condicionar la generación a input o a parámetros específicos
/// * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    [SerializeField]
    [Range(1, 25)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 25)]
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

    List<GameObject> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    #endregion


    #region METHODS

    
    void Start()
    {
       //Generar una esfera nueva el número de veces que me indica el contador
       for(int i = 0; i < totalSpheresToCreate; ++i)
        {
            //GeneratePrefabAtRandomOrigin();
        }

       //Aplicar cambios a todas las esferas que he generado hasta ahora
       for(int a = 0; a < allInstantiatedBallsList.Count; ++a)
        {
            ApplyModificationsToBall(allInstantiatedBallsList[a]);
        }

    }

    void Update()
    {
        //Detectar una tecla para generar una esfera en el spawn origin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }

        //Detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey)) 
        {
            GeneratePrefabAtRandomOrigin();
        }


        //Detectar otra tecla para generar esferas de forma secuencial
        if (Input.GetKeyDown(spawnSequenceKey)) 
        {
            GeneratePrefabSequentially();
        }
    }


    /// <summary>
    /// Genera una instancia de manera secuencial entre varias posiciones ya predefinidas
    /// </summary>
    void GeneratePrefabSequentially()
    {
        //Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //Ubicar la instancia en el origen que le corresponda de la secuencia
        newBall.transform.position = allSequencePointsList[currentSequenceIndex].position;

        //Actualizar el índice de la secuencia para la siguiente vez (asegurando ciclo)
        currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
    }
    /// <summary>
    /// Aplicamos cambios en los parámetros y las físicas de las esferas
    /// </summary>
    /// <param name="currentBall"></param>
    void ApplyModificationsToBall(GameObject currentBall)
    {
        currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
        currentBall.name = "Bola " + Random.value.ToString();
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 250);
    }



    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna la posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {
        //Generar una nueva posición aleatoria usando las variables de rango
        Vector3 newRandomPosition =  new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
        
        //Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //Ubicar el prefab en la posición aleatoria
        newBall.transform.position = newRandomPosition;

        //Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);
    }

    /// <summary>
    /// Crea una instancia de esfera y le asigna la posición elegida dentro de la escena
    /// </summary>
    void GeneratePrefabAtCustomOrigin()
    {
        //Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //Ubica la esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin.position;

        //Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);
    }

    

    #endregion
}
