using System.Collections;
using UnityEngine;

public class B_CoinTrap : MonoBehaviour
{
    #region ATTRIBUTES
    //daño trampa
    [SerializeField][Range(0, 3)] int coinsLost = 1;

    //frecuencia daño trampa
    [SerializeField][Range(0.5f, 3)] float trapFrequency = 1;

    bool playerIsInsideArea = false;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        Debug.Log("El jugador ha entrado");
        StartCoroutine(StealCoinsPlayer(other.GetComponent<B_CharacterController2>()));
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        Debug.Log("esta en COIN TRAP");
    }

    IEnumerator StealCoinsPlayer(B_CharacterController2 player)
    {
        player.EarnMoney(-coinsLost);
        yield return new WaitForSeconds(trapFrequency);

        if (playerIsInsideArea)
        {
            StartCoroutine(StealCoinsPlayer(player));
        }
    }
    #endregion
}
