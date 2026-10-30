using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_CoinsManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 7.5f;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 7.5f;

    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    GameObject superCoinPrefab;

    List<C_SpawnCoin> allInstantiatedCoinsList = new();

    List<C_SpawnSuperCoin> allInstantiatedSuperCoinsList = new();

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.G;

    [SerializeField]
    [Range(1, 10)]
    float creationFrequency = 5;

    #endregion





    #region METHODS

    private void Start()
    {
        StartCoroutine(CreateSuperCoin());
    }

    private void Update()
    {
        // Detectar una tecla para generar una moneda en una posición aleatoria
        if (Input.GetKeyDown(spawnRandomKey))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefab(newRandomPosition);
        }
    }

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
    /// Crea una moneda nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para la nueva moneda </param>
    void GenerateNewSuperPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        C_SpawnSuperCoin newSuperCoin = Instantiate(superCoinPrefab).GetComponent<C_SpawnSuperCoin>();

        // Añadir la esfera a la lista de objetos generados
        allInstantiatedSuperCoinsList.Add(newSuperCoin);
        newSuperCoin.InitializeSuperCoin(this, newPosition);
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
    /// <param name="supercoin"> supermoneda que ha solicitado su fin </param>
    public void FinishSuperCoinLifeCycle(C_SpawnSuperCoin supercoin)
    {
        // Eliminamos la moneda de la lista
        allInstantiatedSuperCoinsList.Remove(supercoin);

        // Destruimos el objeto
        Destroy(supercoin.gameObject);
    }

    IEnumerator CreateSuperCoin()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1.5f, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewSuperPrefab(newRandomPosition);

        yield return new WaitForSeconds(creationFrequency);
        StartCoroutine(CreateSuperCoin());
    }

    #endregion
}