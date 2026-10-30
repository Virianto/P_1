using UnityEngine;
using System.Collections;

/// <summary>
/// Moneda controlada por un manager
/// X Tiene q conservar una referencia al manager
/// X Comunicar al manager cuando deba desaparecer
/// </summary>
public class C_Coin3 : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    GameObject coinBody;

    //[SerializeField]
    //ParticleSystem coinParticles;

    M_CoinSpawn myManager;

    public enum CoinType
    {
        Coin,
        Supercoin
    }
    float lifeTime = 20;

    public CoinType coinType;
    #endregion


    #region METHODS
    public void InitializeCoin(M_CoinSpawn manager, Vector3 spawnPosition, float lifeTime)
    {
        // Asigna la posición directamente al transform del objeto
        myManager = manager;
        transform.position = spawnPosition;

        this.lifeTime = lifeTime;
        StartCoroutine(FinishLifeCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Emitir partículas de despedida
        // coinParticles.Emit(50);

        // Desactivar el spereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        coinBody.SetActive(false);
    }
    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        myManager.FinishCoinLifeCycle(this);
        myManager.FinishSuperCoinLifeCycle(this);
    }

    #endregion
}
