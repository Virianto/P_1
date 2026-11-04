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

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Discernir entre jugador y agentes
        if(other.GetComponent<B_CharacterController>() != null)
        {
            // Herir al jugador
            // Detectar cuándo ha entrado el jugador en su área de efecto
            playerIsInsideArea = true;

            // Invocar una subrutina facilitando en parámetros el componente del player
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }
        if (other.GetComponent<C_Agent>() != null)
        {
            // Herir al agente
            StartCoroutine(HurtAgent(other.GetComponent<C_Agent>()));
        }        
    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
    }

    // Declarar un método con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // Dañar al jugador
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);
        
        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a esta subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }

    IEnumerator HurtAgent(C_Agent agent)
    {
        agent.ModifyAgentLifePoints(-trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        StartCoroutine(HurtAgent(agent));
    }

    #endregion
}
