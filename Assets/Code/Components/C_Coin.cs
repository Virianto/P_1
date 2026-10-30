using System.Collections;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class C_Coin : MonoBehaviour
{

    #region ATTRIBUTES

    M_CoinSpawner myManager;
    float lifeTime = 10;
    public bool isSuperCoin=false;


    #endregion


    #region METHODS


    public void InitializeCoin(M_CoinSpawner manager, Vector3 newPosition, float lifeTime)
    {
        myManager = manager;
        transform.position = newPosition;

        this.lifeTime = lifeTime;
    }
    

    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);

        myManager.FinishCoinLifeCycle(this);
    }
    #endregion
}
