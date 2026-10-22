using UnityEngine;

public class Supermoneda : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource SupercoinAudiosource;

    [SerializeField]
    ParticleSystem SupercoinParticles;

    [SerializeField]
    GameObject SupercoinBody;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de recolección
        SupercoinAudiosource.PlayOneShot(SupercoinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        SupercoinParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        SupercoinBody.SetActive(false);
    }
    #endregion
}