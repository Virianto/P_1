using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
     public int coinValue = 1;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObject coinBody;
    
    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de recolección
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        coinParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        coinBody.SetActive(false);
    }

    #endregion
}
