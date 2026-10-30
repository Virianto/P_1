using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     X Ubicar la esfera en una posicion concreta (facilitada desde el Editor)
///     X Introducir aleatoriedad en posicion de origen y en cantidad de esferas
///     X añadir fisicas en el momento de generar cada esfera
///     X Condicionar la generacion a input o a parametros especificos
///     X Gestionar el ciclo de vida de las esferas generadas
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

    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"></param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();
        allInstantiatedBallsList.Add(newBall);
        newBall.InitializeBall(this,newPosition, Random.value * 5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
        }
        if (Input.GetKeyDown(spawnRandomKey))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefab(newRandomPosition);
        }
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }

    /// <summary>
    /// Destruir una bola cuando su vida llegue a cero
    /// </summary>
    /// <param name="ball"></param>
    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        allInstantiatedBallsList.Remove(ball);
        Destroy(ball.gameObject);
    }

    #endregion
}