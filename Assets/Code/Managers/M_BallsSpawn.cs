using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///  X Ubicar la esfera en una posición concreta facilitada desde el editor
///  X Introducir aleatoriedad en posición de origen y en cantidad de esferas
///  X Añadir físicas en el momento de generar cada esfera
///  X Condicionar la generación a input o a parámetros específicos
///  X Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES
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

    [Space(10)]

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawSequenceKey = KeyCode.J;

    [Header ("REFERENCIAS EXTERNAS")]
    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_BouncingBall> allInstantiatedBallList = new();

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
            //ApplyModificationsToBall(allInstantiatedBallList[a]);
        }
    }

    private void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
            //newBall.name = "NuevaEsferaTemporal";
        }
        
        // Detectar una tecla DIFERENTE para generar una oleada de esferas aleatoria
        if (Input.GetKeyDown(spawnRandomKey))
        {
            // Generar una nueva posición aleatoria
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

            GenerateNewPrefab(newRandomPosition);
        }

        // Detectar OTRA tecla para generar esferas de forma cíclica/secuencial
        if (Input.GetKeyDown(spawSequenceKey))
        {
            GenerateNewPrefab(allSequencePointsList[currentSequenceIndex].position);

            // Actualizar el índice de la secuencia para la siguiente vez
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }

    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition">Ubicación de origen para la nueva esfera</param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        // Generar una instacia del prefab
        //GameObject newBall = Instantiate(ballPrefab);
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();

        // Añadir esta esfera a la lista de objetos generados
        //allInstantiatedBallList.Add(newBall.GetComponent<C_BouncingBall>());
        allInstantiatedBallList.Add(newBall);

        //newBall.GetComponent<C_BouncingBall>().InitializeBall(this, newPosition);
        newBall.InitializeBall(this, newPosition, Random.value * 5);
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" una bola
    /// </summary>
    /// <param name="ball">Bola q ha solicitado su fin</param>
    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        // Elimino la bola de mi lista
        allInstantiatedBallList.Remove(ball);
        // Luego destruyo el objeto
        Destroy(ball.gameObject);
    }
    #endregion
}
