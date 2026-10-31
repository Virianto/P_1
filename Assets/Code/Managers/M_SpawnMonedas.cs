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

    List<C_Monedas> allInstantiatedCoinsLists = new();

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
            currentSequenceIndex = Random.Range(0, allSpawnsPointsList.Count);
            Vector3 spawnPosition = allSpawnsPointsList[currentSequenceIndex].position;
            float radius = 3f;
            Vector2 randomPosition = Random.insideUnitCircle * radius;
            Vector3 finalPosition = new Vector3(
                spawnPosition.x + randomPosition.x,
                2,
                spawnPosition.z + randomPosition.y
            );
            isSuperCoin = Random.Range(0, 2);
            if (isSuperCoin == 0)
            {
                GenerateNewNormalCoinPrefab(finalPosition);
                yield return new WaitForSeconds(5f);
            }
            if (isSuperCoin == 1)
            {
                GenerateNewSuperCoinPrefab(finalPosition);
                yield return new WaitForSeconds(5f);
            }
        }
    }

    public void FinishCoinLifeCycle(C_Monedas coin)
    {

        ParticleSystem particulas = coin.GetComponentInChildren<ParticleSystem>();

        if (particulas != null)
        {
            if (coin.tag == "Coin")
            {
                particulas.transform.SetParent(null);
                particulas.Emit(25);
                var main = particulas.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                Debug.Log("Has recogido una moneda normal");
            }
            else if (coin.tag == "SuperCoin")
            {
                particulas.transform.SetParent(null);
                particulas.Emit(50);
                var main = particulas.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                Debug.Log("Has recogido una super moneda");
            }

        }  
    }

    public void FinishCoinLifeCycleTime(C_Monedas coin)
    {
        allInstantiatedCoinsLists.Remove(coin);
        Destroy(coin.gameObject);
        Debug.Log("nadie me a recogido");
    }
    #endregion
}

