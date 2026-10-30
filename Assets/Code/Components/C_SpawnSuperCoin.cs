using System.Collections;
using UnityEngine;


/// <summary>
/// Monedas que se generan aleatoriamente por el mapa cada cierto tiempo
/// </summary>
public class C_SpawnSuperCoin : MonoBehaviour
{
    #region ATTRIBUTES

    M_CoinsManager MyManager;

    [Range(5, 10)]
    public float lifeTime = 7.5f;

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

    IEnumerator FinishSuperCoinLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(lifeTime);

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishSuperCoinLifeCycle(this);
    }

    #endregion
}