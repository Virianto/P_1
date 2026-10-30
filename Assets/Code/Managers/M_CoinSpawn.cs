using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este manager se ocupa de las monedas, debe:
/// * Ubicar las monedas (normal y super) en donde le diga el editor
/// * Eliminar la moneda cuando detecta que ha sido recogida
/// * Recibir info de una plataforma para cambiar las monedas normales por super o viceversa
/// </summary>
public class M_CoinSpawn : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]
    [SerializeField]
    [Range(0, 30)]
    int totalCoinsToCreate = 1;

    [SerializeField]
    [Range(0, 30)]
    int totalSuperCoinsToCreate = 1;

    // Variable q me permita definir un rango horizontal (X)
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    // Variable q me permita definir un rango de profundidad (Z)
    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [Space]

    [SerializeField]
    [Range(0, 15)]
    float timeBetweenCoins = 1;
    [SerializeField]
    [Range(0, 15)]
    float coinLifeTime = 10;
    [SerializeField]
    [Range(0, 15)]
    float superCoinLifeTime = 10;

    [Header("REFERENCIAS EXTERNAS")]
    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    GameObject superCoinPrefab;

    [SerializeField]
    Transform point1;
    [SerializeField]
    Transform point2;

    List<C_Coin3> allInstantiatedCoinList = new();

    #endregion


    #region METHODS
    // Generar una moneda
    private void Start()
    {
        StartCoroutine(StartCoinLifeCycle());
        StartCoroutine(StartSuperCoinLifeCycle());
    }

    public IEnumerator StartCoinLifeCycle()
    {
        // Genero una moneda el numero de veces indicado
        for (int i = 0; i < totalCoinsToCreate; i++)
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 0, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefabCoin(point1.position + newRandomPosition);

            yield return new WaitForSeconds(timeBetweenCoins);
        }
    }
    public IEnumerator StartSuperCoinLifeCycle()
    {
        for (int a = 0; a < totalSuperCoinsToCreate; a++)
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 0, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefabSuperCoin(point2.position + newRandomPosition);

            yield return new WaitForSeconds(timeBetweenCoins);
        }
    }

    void GenerateNewPrefabCoin(Vector3 newPosition)
    {
        C_Coin3 newCoin = Instantiate(coinPrefab).GetComponent<C_Coin3>();
        allInstantiatedCoinList.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition, Random.value * 10);
    }
    void GenerateNewPrefabSuperCoin(Vector3 newPosition)
    {
        C_Coin3 newCoin = Instantiate(superCoinPrefab).GetComponent<C_Coin3>();
        allInstantiatedCoinList.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition, Random.value * 10);
    }




    /// <summary>
    /// Debería eliminar las monedas
    /// </summary>
    /// <param name="coin">Moneda q se tieen q eliminar</param>
    public void FinishCoinLifeCycle(C_Coin3 coin)
    {
        // Elimino la moneda de mi lista
        allInstantiatedCoinList.Remove(coin);
        // Luego destruyo el objeto
        Destroy(coin.gameObject);
    }

    public void FinishSuperCoinLifeCycle(C_Coin3 supercoin)
    {
        // Elimino la moneda de mi lista
        allInstantiatedCoinList.Remove(supercoin);
        // Luego destruyo el objeto
        Destroy(supercoin.gameObject);
    }

    #endregion
}



