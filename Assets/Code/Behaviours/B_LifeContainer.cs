using UnityEngine;

public class B_LifeContainer : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource containerAudio;

    [SerializeField]
    ParticleSystem containerParticles;

    [SerializeField]
    GameObject containerBody;
    
    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de recolección
        containerAudio.PlayOneShot(containerAudio.clip);
        // Va a emitir unas partículas de despedida
        containerParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        containerBody.SetActive(false);
    }

    #endregion
}
