using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     X Ubicar la esfera en una posición concreta (facilitada desde el Editor)
///     X Introducir aleatoriedad en posición de origen y en cantidad de esferas
///     X Añadir físicas en el momento de generar cada esfera
///     X Condicionar la generación a input o a parámetros específicos
///     * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
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

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_BouncingBall> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    #endregion

    #region METHODS
    
    void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
        }
        // Detectar una tecla DIFERENTE para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey)) 
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefab(newRandomPosition);
        }
        // Detecta OTRA tecla para generar esferas de forma cíclica/secuencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }

    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition">Ubicación de origen para la nueva esfera</param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();

        allInstantiatedBallsList.Add(newBall);
        newBall.InitializeBall(this, newPosition, Random.value * 5);
    }

    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        allInstantiatedBallsList.Remove(ball);
        Destroy(ball.gameObject);
    }
    #endregion
}
