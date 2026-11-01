using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Generar y gestionar el ciclo de vida de las monedas
/// </summary>
public class M_CoinsManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 30)]
    float horizontalXRange = 15;

    [SerializeField]
    [Range(1, 30)]
    float horizontalZRange = 15;

    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    GameObject superCoinPrefab;

    [SerializeField]
    GameObject bombPrefab;

    List<C_SpawnCoin> allInstantiatedCoinsList = new();

    List<C_SpawnSuperCoin> allInstantiatedSuperCoinsList = new();

    List<C_Bomb> allInstantiatedBombsList = new();

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.G;

    public float minCreationFrequency = 1;
    public float maxCreationFrequency = 10;

    #endregion





    #region METHODS

    /// <summary>
    /// Comenzar la corutina al empezar el juego
    /// </summary>
    private void Start()
    {
        StartCoroutine(CreateCoin());
        StartCoroutine(CreateSuperCoin());
        StartCoroutine(CreateBomb());
    }

    /// <summary>
    /// Detectar una tecla para generar una moneda en una posición aleatoria
    /// </summary>
    //private void Update()
    //{
    //    if (Input.GetKeyDown(spawnRandomKey))
    //    {
    //        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
    //        GenerateNewPrefab(newRandomPosition);
    //    }
    //}

    /// <summary>
    /// Crea una moneda nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para la nueva moneda </param>
    void GenerateNewPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_SpawnCoin newCoin = Instantiate(coinPrefab).GetComponent<C_SpawnCoin>();

        // Añadir la esfera a la lista de objetos generados
        allInstantiatedCoinsList.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition);
    }

    /// <summary>
    /// Generar monedas de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateCoin()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewPrefab(newRandomPosition);

        yield return new WaitForSeconds(Random.Range(minCreationFrequency, (maxCreationFrequency - 5)));
        StartCoroutine(CreateCoin());
    }

    /// <summary>
    /// Crea una supermoneda nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para la nueva supermoneda </param>
    void GenerateNewSuperPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_SpawnSuperCoin newSuperCoin = Instantiate(superCoinPrefab).GetComponent<C_SpawnSuperCoin>();

        // Añadir la esfera a la lista de objetos generados
        allInstantiatedSuperCoinsList.Add(newSuperCoin);
        newSuperCoin.InitializeSuperCoin(this, newPosition);
    }

    /// <summary>
    /// Generar supermonedas de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateSuperCoin()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewSuperPrefab(newRandomPosition);

        yield return new WaitForSeconds(Random.Range((minCreationFrequency + 5), maxCreationFrequency));
        StartCoroutine(CreateSuperCoin());
    }

    /// <summary>
    /// Crea una bomba nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para la nueva bomba </param>
    void GenerateNewBomb(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_Bomb newBomb = Instantiate(bombPrefab).GetComponent<C_Bomb>();

        // Añadir la esfera a la lista de objetos generados
        allInstantiatedBombsList.Add(newBomb);
        newBomb.InitializeBomb(this, newPosition);
    }

    /// <summary>
    /// Generar bombas de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateBomb()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewBomb(newRandomPosition);

        yield return new WaitForSeconds(Random.Range(minCreationFrequency, maxCreationFrequency));
        StartCoroutine(CreateBomb());
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" una moneda
    /// </summary>
    /// <param name="coin"> Moneda que ha solicitado su fin </param>
    public void FinishCoinLifeCycle(C_SpawnCoin coin)
    {
        // Eliminamos la moneda de la lista
        allInstantiatedCoinsList.Remove(coin);

        // Destruimos el objeto
        Destroy(coin.gameObject); 
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" una supermoneda
    /// </summary>
    /// <param name="supercoin"> Supermoneda que ha solicitado su fin </param>
    public void FinishSuperCoinLifeCycle(C_SpawnSuperCoin supercoin)
    {
        // Eliminamos la moneda de la lista
        allInstantiatedSuperCoinsList.Remove(supercoin);

        // Destruimos el objeto
        Destroy(supercoin.gameObject);
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" una bomba
    /// </summary>
    /// <param name="supercoin"> Bomba que ha solicitado su fin </param>
    public void FinishBombLifeCycle(C_Bomb bomb)
    {
        // Eliminamos la moneda de la lista
        allInstantiatedBombsList.Remove(bomb);

        // Destruimos el objeto
        Destroy(bomb.gameObject);
    }

    #endregion
}