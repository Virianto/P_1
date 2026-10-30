using System.Collections;
using UnityEngine;

public class B_MoneyTrap : MonoBehaviour
{
    #region ATTRIBUTES

    bool playerIsInsideArea = false;

    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 5;

    [SerializeField]
    [Range(0, 10)]
    int addMoney = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;

    [SerializeField]
    ParticleSystem moneyrain;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        moneyrain.Emit(10);

        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        //StartCoroutine(AddCoinsToPlayer(other.GetComponent<B_CharacterController>()));
    }

    //IEnumerator AddCoinsToPlayer(B_CharacterController player)
    //  {
    //      player.EarnMoney(+coinsWin);

    //      yield return new WaitForSeconds(trapFrequency);

    //      if (playerIsInsideArea)
    //      {
    //          StartCoroutine(AddCoinsToPlayer(player));
    //      }
    //  }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        if (playerIsInsideArea)
        {
            StartCoroutine(HurtPlayer(player));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }


    #endregion
}
