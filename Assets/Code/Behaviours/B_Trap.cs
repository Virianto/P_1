using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES

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
        playerIsInsideArea = true;
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
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
    #endregion
}
