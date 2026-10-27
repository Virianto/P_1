using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{

    #region ATTRIBUTES

    // Daño que hace esta trampa 
    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;
    // Frecuencia con que hace daño esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;
    
    bool playerIsInsideArea = false;

    [SerializeField]
    AudioSource trapAudioSource;

    [SerializeField]
    ParticleSystem trapPatricles;

    #endregion

    #region METHODS

    //Detectar cuándo ha entrado el jugador en su área de efecto
    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        
        //Invocar una subrutina facilitando en parámetros el componente del player
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }
    //Va a dañar al jugador mientras esté dentro

    
    //Detectar cuándo ha salido el jugador de su área de efecto
    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
       
    }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        //Dañar al jugador
        player.TakeDamage(trapDamage);
        trapAudioSource.PlayOneShot(trapAudioSource.clip);
        trapPatricles.Play();


        yield return new WaitForSeconds(trapFrequencyDamage);

        //Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea) 
        {
            StartCoroutine(HurtPlayer(player));
        }

        

        //Volver a llma esta subtrama
    }
    #endregion
}
