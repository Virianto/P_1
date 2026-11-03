using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES
    B_Agent agent;

    [SerializeField]
    [Range(1, 10)]
    int trapDamage = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;

    private bool playerIsInsideArea = false;

    #endregion
    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<B_CharacterController>() !=null)
        {
            playerIsInsideArea = true;
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }
        if (other.GetComponent<B_Agent>() != null)
        {
            // Herir al agente
            StartCoroutine(HurtAgent(other.GetComponent<B_Agent>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        if (playerIsInsideArea)
        {
            StartCoroutine(HurtPlayer(player));
        }
    }
    IEnumerator HurtAgent(B_Agent agent)
    {
        agent.ModifyAgentLifePoints(-trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        StartCoroutine(HurtAgent(agent));
    }
    #endregion
}
