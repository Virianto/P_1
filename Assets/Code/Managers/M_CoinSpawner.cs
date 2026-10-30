using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de generar monedas de forma aleatoria en el mapa.
/// </summary>
public class M_CoinSpawner : MonoBehaviour
{

    #region ATTRIBUTES

    

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 30)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 30)]
    float horizontalZRange = 2;

    [SerializeField]
    [Range(1, 300)]
    float timeBetweenSpawns = 3;


    [Header("REFERENCIAS EXTERNAS")]
    
    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    GameObject superCoinPrefab;
    [SerializeField]
    B_CoinCharacter player;

    List<C_Coin> allInstantiatedCoinsList = new();
    List<C_Coin> allInstantiatedSuperCoinsList = new();

    #endregion


    #region METHODS

    void Start()
    {
        StartCoroutine(CoinSpawnTimeCycle());
        StartCoroutine(SuperCoinSpawnTimeCycle());
    }


    void Update()
    {
    }
    void GenerateNewPrefab(Vector3 newPosition)
    {
        //Generar una instancia del prefab
        C_Coin newCoin = Instantiate(coinPrefab).GetComponent<C_Coin>();
        allInstantiatedCoinsList.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition,Random.value *15);

    }
    void GenerateNewSuperPrefab(Vector3 newPosition)
    {
        //Generar una instancia del prefab
        C_Coin newSuperCoin = Instantiate(superCoinPrefab).GetComponent<C_Coin>();
        allInstantiatedSuperCoinsList.Add(newSuperCoin);
        newSuperCoin.InitializeCoin(this, newPosition,Random.value *15);

    }

    IEnumerator CoinSpawnTimeCycle()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 1, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewPrefab(newRandomPosition);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(CoinSpawnTimeCycle());
    }
    IEnumerator SuperCoinSpawnTimeCycle()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 0, Random.Range(-horizontalZRange, horizontalZRange));
        GenerateNewSuperPrefab(newRandomPosition);
        yield return new WaitForSeconds(Random.Range(5, 15));
        StartCoroutine(SuperCoinSpawnTimeCycle());
    }

    public void FinishCoinLifeCycle(C_Coin coin)
    {
        //Elimino la bola de mi lista
        allInstantiatedCoinsList.Remove(coin);

        //Destruyo el objeto
        Destroy(coin.gameObject);
    }
    #endregion
}
