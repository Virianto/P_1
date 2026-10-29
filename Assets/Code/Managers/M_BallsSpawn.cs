using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Esta clase se encarga de generar esferas en escena siguiendo algunas condiciones.
///     * Ubicar la efera en na posicion concreta, facilitada desde el Editor.       
///     * Introducir aleatoriedad en una posición concreta (facilitada desde el Editor)
///     * Añadir físicas en el momento de generar cada esfera.
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

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnOrigin;

    List<GameObject> allInstantiatedBallsList = new();
    
    #endregion

    #region METHODS
    void Start()
    {
        //generar una esfera nueva el num de veces q me indica el contador
        for (int i = 0; i < sphereToCreate; i++)
        {
            //GeneratePrefabAtCustomOrigin();
            GeneratePrefabAtRandomOrigin();
        }
    }
    void GeneratePrefabAtRandomOrigin()
    {
        //generar uan nueva posición aleatoria
        Vector3 newRandomPosition = new Vector3
            (Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));

        //generar instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //ubicar el prefab en la posición aleatoria
        newBall.transform.position = newRandomPosition;
    }

    void GeneratePrefabAtCustomOrigin()
    {
        //generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        //ubicar la esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin.position;
    }

    #endregion
}
