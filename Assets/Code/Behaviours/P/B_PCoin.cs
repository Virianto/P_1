using UnityEngine;

public class B_PCoin : MonoBehaviour
{
    #region ATTRIBUTES
    
 
    
    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticles;


    [SerializeField]
    GameObject coinBody;

    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        //Va a reproducir un sonido de recolección
        //Va a emitir unas partículas de despedida
        //coinAudioSource.PlayOneShot(coinAudioSource.clip);
        
        coinParticles.Emit(100);

        //Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        //Desactivar el render del hijo
        coinBody.SetActive(false);
    }

    #endregion
}
