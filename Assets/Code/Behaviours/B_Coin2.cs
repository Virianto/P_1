using System;
using UnityEngine;

public class B_Coin2 : MonoBehaviour
{
    // Detectar la colisión con el jugador (SOLAMENTE EL JUGADOR)

    // Reproducir sonido de reproducción

    // Emitir partículas de despedida

    // Desaparecer

    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticles;


    // ¿Cuántas monedas ha recogido mi jugador?
    #endregion


    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        
    }


    #endregion
}
