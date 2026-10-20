using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Va a reproducir un sonido de recolección
        // Va a emitir unas partículas de despedida
        // Va a desaparecer
    }
    #endregion
}