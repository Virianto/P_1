using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     X Ubicar la esfera en una posición concreta (facilitada desde el Editor)
///     X Introducir aleatoriedad en posición de origen y en cantidad de esferas
///     * Añadir físicas en el momento de generar cada esfera
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

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;
    
    List<GameObject> allInstantiatedBallList = new();

    List<GameObject> allInstantiatedBallsList = new();

    [SerializeField] KeyCode spawnRandomKey = KeyCode.None;
    [SerializeField] KeyCode spawnCustomKey = KeyCode.None;
    [SerializeField] KeyCode spawnSequeanceKey = KeyCode.None;
    

    #endregion

    #region METHODS
    
    void Start()
    {
        // Generar una esfera nueva el número de veces que me indica el contador
        for (int i = 0; i < totalSpheresToCreate; ++i)
        {            
            GeneratePrefabAtRandomOrigin();
        }

        // Aplicar cambios a todas las esferas que he generado hasta ahora (recorrer lista)
        for (int a = 0; a < allInstantiatedBallsList.Count; ++a) 
        {
            ApplyModificationsToBall(allInstantiatedBallsList[a]);
        }
    }

    void ApplyModificationsToBall(GameObject currentBall)
    {
        currentBall.GetComponent<Renderer>().material.color = Random.ColorHSV();
        currentBall.name = "Bola " + Random.value.ToString();
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 150);
    }

    /// <summary>
    /// Crea una posición aleatoria, instancia una esfera y le asigna la posición
    /// </summary>
    void GeneratePrefabAtRandomOrigin()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
             
        GameObject newBall = Instantiate(ballPrefab);
                
        newBall.transform.position = newRandomPosition;

        // Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);
    }

    void GeneratePrefabAtCustomOrigin()
    {
        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        // Ubicar la esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin.position;

        // Añadir esta esfera a la lista de objetos generados
        allInstantiatedBallsList.Add(newBall);
    }
    private void Update()
    {
        if (Input.GetKeyDown(spawnCustomKey))
        {
            GeneratePrefabAtCustomOrigin();
        }
        if (Input.GetKeyDown(spawnRandomKey))
        {
            GeneratePrefabAtRandomOrigin();
        }
        if (Input.GetKeyDown(spawnSequeanceKey))
        {

        }
    }
    #endregion
}
