using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// CREAR SISTEMA MANAGER PARA MONEDAS
/// * Debe funcionar como las esferas
/// * Dos tipos de monedas, el manager genera ambas siguiendo indicaciones
/// * Se pueden poner varios managers en la escena (uno para cada zona)
/// * Cuando la moneda es recogida, debe informarse al manager para q la elimine
/// * HABRA UNA PLATAFORMA QUE CONVIERTA TODAS LAS MONEDAS DE UN MANAGER EN SUPER O NORMALES (lo contrario a lo q fueran).
/// </summary>
public class M_CoinManager : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("Normal Coins")]
    [SerializeField] GameObject normalCoinPrefab;
    [SerializeField] int normalCoinsToSpawn;

    [Header("Super Coins")]
    [SerializeField] GameObject superCoinPrefab;
    [SerializeField] int superCoinsToSpawn;

    [Header("Location between: ")]
    [SerializeField] float axisX=2;
    [SerializeField] float axisZ=2;
    
    
    #endregion

    #region METHODS
    void Start()
    {
        for (int i=0; i<normalCoinsToSpawn; i++)
        {
            GameObject newCoin = Instantiate(normalCoinPrefab);
            newCoin.transform.position = new Vector3(Random.Range(-axisX, axisX), 0.7f, Random.Range(-axisZ, axisZ));
        }

        for (int i = 0; i < superCoinsToSpawn; i++)
        {
            GameObject newCoin = Instantiate(superCoinPrefab);
            newCoin.transform.position = new Vector3(Random.Range(-axisX, axisX), 0.7f, Random.Range(-axisZ, axisZ));
        }

    }

    #endregion
}
