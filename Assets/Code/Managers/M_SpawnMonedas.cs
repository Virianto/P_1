using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X Generar Monedas en un punto determinado
/// X generar Monedas en puntos aleatorios
/// * Variar entre monedas normales y super
/// * Eliminar la moneda cuando esta sea recogida
/// </summary>

public class M_SpawnMonedas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject monedaNormalPrefab;

    [SerializeField]
    GameObject monedaSuperPrefab;

    int currentSequenceIndex = 0;

    int isSuperCoin = 0;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    List <C_Monedas> allInstantiatedCoinsLists = new();

    [SerializeField]
    List<Transform> allSpawnsPointsList = new();

    #endregion
    #region METHODS

    void GenerateNewNormalCoinPrefab(Vector3 newPosition)
    {
        C_Monedas newCoin = Instantiate(monedaNormalPrefab).GetComponent<C_Monedas>();
        allInstantiatedCoinsLists.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition);
    }

    void GenerateNewSuperCoinPrefab(Vector3 newPosition)
    {
        C_Monedas newCoin = Instantiate(monedaSuperPrefab).GetComponent<C_Monedas>();
        allInstantiatedCoinsLists.Add(newCoin);
        newCoin.InitializeCoin(this, newPosition);
    }

    private void Start()
    {
        StartCoroutine(CountingStartLifeCycle());
    }

    IEnumerator CountingStartLifeCycle()
    {
        while (true)
        {
            isSuperCoin = Random.Range(0,2);
            Debug.Log(isSuperCoin);
            if (isSuperCoin == 0)
            {
                currentSequenceIndex = Random.Range(0, allSpawnsPointsList.Count);
                horizontalXRange = allSpawnsPointsList[currentSequenceIndex].position.x;
                horizontalZRange = allSpawnsPointsList[currentSequenceIndex].position.z;
                GenerateNewNormalCoinPrefab(new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange)));
                Debug.Log("Estoy en el spawnPoint " + currentSequenceIndex + " y soy una moneda normal");
                yield return new WaitForSeconds(5f);
            }
            if (isSuperCoin == 1)
            {
                currentSequenceIndex = Random.Range(0, allSpawnsPointsList.Count);
                horizontalXRange = allSpawnsPointsList[currentSequenceIndex].position.x;
                horizontalZRange = allSpawnsPointsList[currentSequenceIndex].position.z;
                GenerateNewSuperCoinPrefab(new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 0, Random.Range(-horizontalZRange, horizontalZRange)));
                Debug.Log("Estoy en el spawnPoint " + currentSequenceIndex + " y soy una super moneda");
                yield return new WaitForSeconds(5f);
            }
        }
    }

    public void FinishCoinLifeCycle(C_Monedas coin)
    {
        //GetComponent<C_Monedas>().GetComponentInChildren<ParticleSystem>().Emit(25);
        allInstantiatedCoinsLists.Remove(coin);
        Destroy(coin.gameObject);
    }

    #endregion
}

