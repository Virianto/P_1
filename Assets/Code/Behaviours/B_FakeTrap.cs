using System.Collections;
using TMPro;
using UnityEngine;

public class B_FakeTrap : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 3)]
    int coinsLost = 1;

    // Frecuencia con que hace roba dinero esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 1;

    bool playerIsInsideArea = false;

    ParticleSystem particle;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;

        StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));

        if (playerIsInsideArea == true)
        {
            particle.Play();
        }
    }
    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {
        
        player.EarnMoney(+coinsLost);

        yield return new WaitForSeconds(trapFrequency);

        if (playerIsInsideArea)
        {
            StartCoroutine(StealCoinsToPlayer(player));
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        if (playerIsInsideArea == false)
        {
            particle.Stop();
        }
    }

    #endregion
}
