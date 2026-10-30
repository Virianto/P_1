using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// generar esfereas en escena siguiendo ciertas condiciones
/// ubiar la esferea en cierta posicion 
/// introducir aleatoriedad en posicion de origen y cantidad de esferas
/// añadir fisicas en el momento de generar cada esfera
/// gestionar el ciclo de vida de las esferas generadas
/// condicionar la generacion a input o a parametros especificos
/// </summary>

public class M_ballspawn : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalSpheres = 1;

    //añadir una variable que me permita definir un rango horizontal en x y un rango de profundidad z

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawnSequenceKey = KeyCode.J;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    int currentSequenceIndex = 0;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    List<GameObject> allInstantiateBallsList = new();

    List<C_bouncingball>

    #endregion

    #region METHODS

    // generar esfera en escena(funcion estatica)
    private void Start()
    {
        for (int i = 0; i < totalSpheres; i++)
        {
            GeneratePrefabAtCustomOrigin();
            GeneratePrefabAtRandomOrigin();
        }
        //aplicar cambios a todas las esferas que he generado hasta ahora
        for(int a = 0; a < allInstantiateBallsList.Count; ++a)
        {
            ApplyModificationsToBall(allInstantiateBallsList[a]);
        }
    }

    private void Update()
    {
        //detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GeneratePrefabAtCustomOrigin();
        }
        //detectar una tecla diferente para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey))
        {
            GeneratePrefabAtRandomOrigin();
        }
        //detecta otra tecla para generar esferas de forma ciclica/secuencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GeneratePrefabSequentially();
        }
    }
    void ApplyModificationsToBall(GameObject currentBall)
    {
        currentBall.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        currentBall.GetComponent<Rigidbody>().AddExplosionForce(300, Vector3.zero, 150);
    }

    void GeneratePrefabAtRandomOrigin()
    {
        //genrar nueva posicion aleatoria
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
        //generar instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);
        //ubicar el prefab en posicion aleatoria
        newBall.transform.position = newRandomPosition;
        //allInstantiateBallsList.Add(newBall.GetComponent<C_bouncingball>());
    }
  
    void GeneratePrefabAtCustomOrigin()
    {
        GameObject newBall = GenerateNewPrefab(spawnOrigin.position);
        //newBall.transform.position = spawnOrigin.position;
        //allInstantiateBallsList.Add(newBall.GetComponent<C_bouncingball>());
    }
 void GeneratePrefabSequentially()
    {
        //generar instancia nueva del prefab
        GameObject newBall = Instantiate(ballPrefab);
        //ubicar la instancia en el origen que le corresponda de la secuencia
        newBall.transform.position = allSequencePointsList[currentSequenceIndex].position;
        //actualizar el indice de la secuencia
        currentSequenceIndex = currentSequenceIndex + 1 % allSequencePointsList.Count;
        //allInstantiateBallsList.Add(newBall.GetComponent<C_bouncingball>());

    }
    GameObject GenerateNewPrefab(Vector3 newPosition)
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = newPosition;
        //allInstantiateBallsList.Add(newBall.GetComponent<C_bouncingball>());
        newBall.GetComponent<C_bouncingball>().InitializeBall(this);
        return newBall;
    }

    #endregion
}

