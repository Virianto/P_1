using System.Collections;
using UnityEngine;


/// <summary>
/// Monedas que se generan aleatoriamente por el mapa cada cierto tiempo
/// </summary>
public class C_SpawnSuperCoin : MonoBehaviour
{
    #region ATTRIBUTES

    M_CoinsManager MyManager;

    public float minLifeTime = 5;
    public float maxLifeTime = 15;

    #endregion





    #region METHODS

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeSuperCoin(M_CoinsManager manager, Vector3 newPosition)
    {
        MyManager = manager;
        transform.position = newPosition;
        
        StartCoroutine(FinishSuperCoinLifeCycle());
    }

    /// <summary>
    /// Gestionar el ciclo de vida de las supermonedas
    /// </summary>
    IEnumerator FinishSuperCoinLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishSuperCoinLifeCycle(this);
    }

    #endregion
}