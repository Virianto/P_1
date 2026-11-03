using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES
    // Daño q hace la trampa
    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrecuencyDamage = 1;

    bool playerIsInsideArea = false;
    bool agentIsInsideArea = false;
    #endregion


    #region METHODS
    // Detectar cuándo ha entrado el jugador en el área de efecto
    private void OnTriggerEnter(Collider other)
    {
        // Si detecta al jugador:
        if (other.GetComponent<B_CharacterController>() != null)
        { 
            playerIsInsideArea = true;

            // Invocar una subrutina facilitando por parámetros el componente del player
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }
        // Si detecta a mis agentes:
        else if (other.GetComponent<C_Agent>() != null)
        {
            agentIsInsideArea = true;
            StartCoroutine(HurtAgent(other.GetComponent<C_Agent>()));
        }
    }

    // Declarar un método (subrutina) con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // dañar al jugador
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrecuencyDamage);
        
        // Comprobar si el jugador sigue estando dentro
        if (agentIsInsideArea)
        {
            // Volver a llamar a la subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }

    IEnumerator HurtAgent(C_Agent agent)
    {
        // dañar al jugador
        agent.MofifyAgentLifePoints(trapDamage);

        yield return new WaitForSeconds(trapFrecuencyDamage);

        //Una vez q pasa por aquí se le va quitando vida continuamente
        StartCoroutine(HurtAgent(agent));
    }

    // Detectar cuándo ha salido el jugador en el área de efecto
    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        agentIsInsideArea = false;
    }
    #endregion
}
