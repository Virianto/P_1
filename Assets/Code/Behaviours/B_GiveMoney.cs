using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_GiveMoney : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 3)]
    int coinsGained = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float coinFrequency = 1;

    bool playerIsInsideArea = false;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;

        StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));

    }

    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {

        // Le pongo un - delante a la variable porque el método suma únicamente
        player.EarnMoney(+coinsGained);

        // Esperamos la frecuencia indicada en la variable
        yield return new WaitForSeconds(coinFrequency);

        // Comprobamos si sigue dentro para seguir robando
        if (playerIsInsideArea)
        {

            StartCoroutine(StealCoinsToPlayer(player));
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }






    #endregion

}
