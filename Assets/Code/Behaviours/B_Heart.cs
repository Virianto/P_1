using System.Collections;
using UnityEngine;

public class B_Heart : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource heartAudioSource;

    [SerializeField]
    ParticleSystem heartParticles;

    [SerializeField]
    GameObject heartBody;
    
    //NO LOGRÉ HACERLO, MIRAR CHARACTER CONTROLER
    //[SerializeField]
    //[Range(0, 10)]
    //public int lifeAmount = 5;
    B_CharacterController player;
    #endregion


    #region METHODS

    // Detectar la colisión con el jugador (SOLAMENTE EL JUGADOR)

    private void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de reproducción
        heartAudioSource.PlayOneShot(heartAudioSource.clip);

        // Emitir partículas de despedida
        heartParticles.Emit(50);

        // darle vida al jugador
        //player.GiveLife(lifeAmount);

        // Desactivar el spereCollider para prevenir más recogidas
        GetComponent<Collider>().enabled = false;

        // desactivar el render del hijo para q el jugador deje de verlo

        // GetComponentInChildren<Renderer>().enabled = false;       UNA MANERA DE HACERLO, SI NO ME PILLARA EL OBJETO HACER EL SerializeField Y LO SIGUIENTE:
        heartBody.SetActive(false);

    }


    #endregion
}
