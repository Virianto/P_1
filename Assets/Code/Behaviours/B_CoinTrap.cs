using System.Collections;
using UnityEngine;

public class B_CoinTrap : MonoBehaviour
{
    #region ATTRIBUTES

    //daño que hace esta trampa
    //frecuencia con la que hace daño

    public enum TrapType
    {
        trap1,
        trap2,
        trap3,
    }

    [SerializeField]
    [Range(1, 3)]
    int coinsLost = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 1;

    bool playerIsInsideArea = false;


    #endregion

    #region METHODS

    //detectar cuando ha entrado el playe rne su area de efecto
    //detectar cuando ha salido el player
    //quitar monedas al player mientars este dentro

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        StartCoroutine(StealPlayer(other.GetComponent<B_CharacterController>())); //invocar una subrutina facilitando en parametros el componente del player
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    IEnumerator StealPlayer(B_CharacterController player)
    {
        player.EarnMoney(-coinsLost);

        yield return new WaitForSeconds(trapFrequency);

        if (playerIsInsideArea)
        {
            StartCoroutine(StealPlayer(player));
        }
    }

    #endregion
}
