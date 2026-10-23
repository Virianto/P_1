using UnityEngine;

// Un enumerado puede vivir fuera de cualquier clase de mi código

public class B_SuperCoin : MonoBehaviour
{
    #region ATTRIBUTES


    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticleSystem;

    [SerializeField]
    GameObject coinBody;



    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        coinAudioSource.PlayOneShot(coinAudioSource.clip);

        coinParticleSystem.Emit(70); 

        GetComponent<Collider>().enabled = false;

        coinBody.SetActive(false); 


    }

    #endregion
}
