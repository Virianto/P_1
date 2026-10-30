using System.Collections;
using UnityEngine;


/// <summary>
/// Monedas que se generan en posiciones aleatorias al pulsar una tecla
/// </summary>
public class C_SpawnCoin : MonoBehaviour
{
    #region ATTRIBUTES

    M_CoinsManager MyManager;

    [Range(10, 20)]
    public float lifeTime = 15;

    #endregion





    #region METHODS

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeCoin(M_CoinsManager manager, Vector3 newPosition)
    {
        MyManager = manager;
        transform.position = newPosition;

        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(lifeTime);

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishCoinLifeCycle(this);
    }

    #endregion
}