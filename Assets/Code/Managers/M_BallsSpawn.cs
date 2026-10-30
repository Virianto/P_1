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

    //[SerializeField]
    //[Range(1, 300)]
    //int totalSpheresToCreate = 1;

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

    List<C_BouncingBall> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    #endregion


    #region METHODS

    void Update()
    {   
        //Detectar una tecla para generar una esfera en el spawn origin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
        }

        //Detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey)) 
        {
            //Generar una nueva posición aleatoria usando las variables de rango
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

            GenerateNewPrefab(newRandomPosition);
        }


        //Detectar otra tecla para generar esferas de forma secuencial
        if (Input.GetKeyDown(spawnSequenceKey)) 
        {
            GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);

            //Actualizar el índice de la secuencia para la siguiente vez (asegurando ciclo)
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }
    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition">Ubicación de origen para la nueva esfera</param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        //Generar una instancia del prefab
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();

        //Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);

        newBall.InitializeBall(this, newPosition, Random.value * 5);

    }
    /// <summary>
    /// Ejecuta las funciones necesarias para acabar con una bola
    /// </summary>
    /// <param name="ball">Bola que ha solicitado su fin</param>
    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        //Elimino la bola de mi lista
        allInstantiatedBallsList.Remove(ball);

        //Destruyo el objeto
        Destroy(ball.gameObject);
    }

    #endregion
}
