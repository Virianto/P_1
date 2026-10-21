using UnityEngine;

public class B_SuperCoin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource superCoinAudioSource;

    [SerializeField]
    ParticleSystem superCoinParticles;

    [SerializeField]
    GameObject superCoinBody;

    #endregion

    #region METHODS



    void OnTriggerEnter(Collider other)
    {
        //Va a reproducir un sonido de recolección
        //Va a emitir unas partículas de despedida
        superCoinAudioSource.PlayOneShot(superCoinAudioSource.clip);
        superCoinParticles.Emit(300);

        //Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        //Desactivar el render del hijo
        superCoinBody.SetActive(false);





    }

    #endregion
}