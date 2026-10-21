using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField] GameObject coinBody;
    
    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        coinParticles.Play();
        GetComponent<Collider>().enabled = false;
        coinBody.SetActive (false);
        
    }
    #endregion
}
