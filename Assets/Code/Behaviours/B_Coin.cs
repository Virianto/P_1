using System;
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

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Coin")
        {
            coinAudiosource.PlayOneShot(coinAudiosource.clip);
            coinParticles.Emit(50);
            GetComponent<Collider>().enabled = false;
            coinBody.SetActive(false);
            Debug.Log("soy una moneda normal");
        }
        if (tag == "SuperCoin")
        {
            coinAudiosource.PlayOneShot(coinAudiosource.clip);
            coinParticles.Emit(500);
            GetComponent<Collider>().enabled = false;
            coinBody.SetActive(false);
            Debug.Log("soy una super moneda");
        }
    }
    #endregion
}
