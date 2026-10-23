using UnityEngine;

public class B_Healer : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource healerAudioSource;

    [SerializeField]
    ParticleSystem healerParticleSystem;

    [SerializeField]
    GameObject healerBody;

    [SerializeField]
    [Range(0, 10)]
    int healAmount = 1;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {

        B_CharacterController player = other.GetComponent<B_CharacterController>();

        healerAudioSource.PlayOneShot(healerAudioSource.clip); 

        healerParticleSystem.Emit(50);

        GetComponent<Collider>().enabled = false;

        healerBody.SetActive(false); 


    }

    #endregion
}
