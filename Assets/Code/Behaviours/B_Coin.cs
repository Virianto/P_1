using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticles;

    #endregion

    #region METHODS

   

    void OnTriggerEnter(Collider other)
    {
        //Va a reproducir un sonidode recolección
        //Va a emitir unas partículas de despedida
        //Va a desaparecer
        if (other.GetComponent<B_CharacterController>())
        {
            coinParticles.Emit(250);
            coinAudioSource.PlayOneShot(coinAudioSource.clip);
            gameObject.SetActive(false);

        }
        
   
   
        
    }
   
    #endregion
}
