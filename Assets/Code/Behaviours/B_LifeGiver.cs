using UnityEngine;

public class B_LifeGiver : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource lifeAudioSource;

    [SerializeField]
    ParticleSystem lifeGiverParticles;

    [SerializeField]
    GameObject lifeGiverBody;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        //Va a reproducir un sonido de recolección
        //Va a emitir unas partículas de despedida
        lifeAudioSource.PlayOneShot(lifeAudioSource.clip);
        lifeGiverParticles.Emit(100);

        //Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        //Desactivar el render del hijo
        lifeGiverBody.SetActive(false);
        #endregion
    }
}