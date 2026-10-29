using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
/// * Ubicar la esfera en una posición concreta (facilitada desde el editor)
/// * Introducir aleatoriedad en posición de origen y en cantidad de esferas
/// * Añadir físicas en el momento de generar cada esfera
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

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    #endregion


    #region METHODS

    
    void Start()
    {
       //Generar una esfera nueva el número de veces que me indica el contador
       for(int i = 0; i < totalSpheresToCreate; ++i)
        {
            GeneratePrefabAtRandomOrigin();
        }


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
    }

    

    #endregion
}
