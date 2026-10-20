using UnityEngine;

public class B_Coin2 : MonoBehaviour
{
    /*Detectar la colisión con el jugador solamente
     * Reproducir sonido de recolección
     * Emitir partículas de despedida
     * Desaparecer
     */
    #region ATTRIBUTES
    [SerializeField] AudioSource coinAudioSource;

    [SerializeField] ParticleSystem coinParticles;
    #endregion

    #region METHODS
    #endregion
}
