using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObject coinBody;
    public bool isCoincollected;

    M_EthanCoinManager coinManager;

    #endregion

    #region METHODS
    public void Start()
    {
        coinManager.GetComponent<M_EthanCoinManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        SmallCoinCollected();
    }
    void SmallCoinCollected()
    {
        
        // Reproducir sonido de recolección
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        coinParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        coinBody.SetActive(false);
        isCoincollected = true;
        if (isCoincollected)
        {
            

            coinManager.destroySmallCoin(this);
        }
        
    }
    #endregion
}
