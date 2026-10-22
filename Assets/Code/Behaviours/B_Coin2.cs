using UnityEngine;

public class B_Coin2 : MonoBehaviour
{
    /*Detectar la colisión con el jugador solamente
     * Reproducir sonido de recolección
     * Emitir partículas de despedida
     * Desaparecer
     */
    #region ATTRIBUTES
    [SerializeField] AudioSource coinAudioSource;

    [SerializeField] ParticleSystem coinParticles;
    [SerializeField] GameObject coinBody;
    public enum CoinType
    {
        Normal,
        Mega
    }
    public CoinType myCoinType;
    #endregion

    #region METHOD

    void OnTriggerEnter(Collider other)
    {
        coinAudioSource.PlayOneShot(coinAudioSource.clip);

        if (myCoinType == CoinType.Normal)
        {
            coinParticles.Emit(50);
            Debug.Log("es normal");
        } else if (myCoinType == CoinType.Mega)
        {
            coinParticles.Emit(100);
            Debug.Log("es mega");
        }

        //desactivar el collider
        GetComponent<Collider>().enabled = false;

        //desactivar el renderer del hijo para que el jugador deje de ver la moneda
        GetComponentInChildren<Renderer>().enabled = false;
        coinBody.SetActive(false);
        //gameObject.SetActive(false);
    }
    #endregion
}
