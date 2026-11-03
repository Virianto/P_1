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
    bool agentIsInsideArea = false;

    [SerializeField]
    AudioSource trapAudioSource;

    [SerializeField]
    ParticleSystem trapPatricles;

   

    #endregion

    #region METHODS

    //Detectar cuándo ha entrado el jugador en su área de efecto
    private void OnTriggerEnter(Collider other)
    {
        
        
        //Invocar una subrutina facilitando en parámetros el componente del player
        if (other.GetComponent<B_CharacterController>() != null)
        {
            playerIsInsideArea = true;
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }
        if (other.GetComponent<C_Agent>() != null)
        {
            agentIsInsideArea = true;
            StartCoroutine(HurtAgent(other.GetComponent<C_Agent>()));
        }

    }
    //Va a dañar al jugador mientras esté dentro

    
    //Detectar cuándo ha salido el jugador de su área de efecto
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<B_CharacterController>() != null)
        {
            playerIsInsideArea = false;
        }
        if (other.GetComponent<C_Agent>() != null)
        {
            agentIsInsideArea = false;
        }
       
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

    IEnumerator HurtAgent(C_Agent agent)
    {
        agent.ModifyAgentLifePoints(trapDamage);
        trapAudioSource.PlayOneShot(trapAudioSource.clip);
        trapPatricles.Play();

        yield return new WaitForSeconds(trapFrequencyDamage);

        if (agentIsInsideArea)
        {
            StartCoroutine(HurtAgent(agent));
        }
    }
    #endregion
}
