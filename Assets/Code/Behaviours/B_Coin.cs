using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObjetc coinBody;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {

        // Va a reproducir un sonido de recolección
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        coinParticles.Emit(50);
        // Va a desaparecer
        GetComponent<Collider>().enabled = false;
        //desactivar el render 
        GetComponentInChildren<Crendered>

    }
    #endregion
}
