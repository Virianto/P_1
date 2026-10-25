using UnityEngine;

public class B_PSuperCoin : MonoBehaviour
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

        //coinAudioSource.PlayOneShot(coinAudioSource.clip);
        coinParticles.Emit(100);

        GetComponent<Collider>().enabled = false;

        coinBody.SetActive(false);
    }

    #endregion
}
