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

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    #endregion
}
