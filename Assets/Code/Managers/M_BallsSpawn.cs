using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Esta clase se encarga de generar esferas en escena siguiendo algunas condiciones.
///     * Ubicar la efera en na posicion concreta, facilitada desde el Editor.       
///     * Introducir aleatoriedad en una posici�n concreta (facilitada desde el Editor)
///     * A�adir f�sicas en el momento de generar cada esfera.
///     * Condicionar la generaci�n a input o par�metros espec�ficos.   
///     * Gestionar el ciclo de vida de las esferas generadas.
/// </summary>
public class M_BallsSpawn : MonoBehaviour
    {
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]

    //[SerializeField]
    //[Range(0, 100)]
    //int sphereToCreate = 1;

    //a�adir una variable q permita definir un rango horizontal
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [Space(10)]

    [SerializeField] KeyCode spawnAtOriginKey = KeyCode.G;
    [SerializeField] KeyCode spawnRandomKey = KeyCode.H;
    [SerializeField] KeyCode spawnSequenceKey = KeyCode.J;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnOrigin;

    [SerializeField] List<Transform> allSequencePointsList;
    int currentSequenceIndex = 0;

    List<C_BouncingBall> allInstantiatedBallsList = new();
    //List<C_BouncingBall>


    #endregion

    #region METHODS
    void Update()
    {
        //detectar una tecla para generar una esfera en el spawnOrigin
        if(Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefab(spawnOrigin.position);
        }

        //detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey))
        {
            Vector3 newRandomPosition = new Vector3
                (Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
            
            GeneratePrefab(newRandomPosition);
        }

        // detectar otra tecla para generar esferas de forma ciclica o sequencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GeneratePrefab(allSequencePointsList[currentSequenceIndex].position);
            currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
        }
    }

    /// <summary>
    /// Crea una esfera nueva, la registra en la escena y la inicializa.
    /// </summary>
    /// <param name="newOrigin">Ubicaci�n de origen para la nueva escena</param>
    void GeneratePrefab(Vector3 newOrigin)
    {
        //generar una instancia del prefab
        //GameObject newBall = Instantiate(ballPrefab);
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();

        //ubicar la instancia en el origen q le corresponda
        allInstantiatedBallsList.Add(newBall);

        newBall.InitializeBall(this, newOrigin, Random.value*5);
    }
    
    /// <summary>
    /// Ejecuta las funciones necesarias para finiquitar una bola
    /// </summary>
    /// <param name="ball">Bola q ha solicitado su fin</param>
    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        //elimino la bola de la lista
        allInstantiatedBallsList.Remove(ball);

        //destruyo la bola
        Destroy(ball.gameObject);
    }
    #endregion
}
