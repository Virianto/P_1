using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Esta clase controlara las caracteristicas de las monedas
/// </summary>

public class C_Monedas : MonoBehaviour
{
    #region ATTRIBUTES

    M_SpawnMonedas myManager;
    int isSuperCoin = 0;

    #endregion
    #region METHODS

    public void InitializeCoin(M_SpawnMonedas manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;  
        gameObject.name = "Coin " + Random.value.ToString();
        StartCoroutine(CountingStartLifeCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
            myManager.FinishCoinLifeCycle(this);
    }

    IEnumerator CountingStartLifeCycle()
    {
        yield return new WaitForSeconds(Random.Range(10,15));
        myManager.FinishCoinLifeCycleTime(this);
    }
        #endregion
    }

