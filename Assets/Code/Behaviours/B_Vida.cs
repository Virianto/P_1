using UnityEngine;

public class B_Vida : MonoBehaviour
{
    #region ATTRIBUTES

    public int healAmount = 5;

    [SerializeField]
    AudioSource vidaAudiosource;

    [SerializeField]
    ParticleSystem vidaParticles;

    [SerializeField]
    GameObject vidaBody;
    
    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de recolección
        vidaAudiosource.PlayOneShot(vidaAudiosource.clip);
        // Va a emitir unas partículas de despedida
        vidaParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        vidaBody.SetActive(false);
    }

    #endregion
}
