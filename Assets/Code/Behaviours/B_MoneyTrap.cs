using System.Collections;
using UnityEngine;

public class B_MoneyTrap : MonoBehaviour
{
    // Detectar cuando he entrado en contacto con el jugador
    // Quitarle monedas al jugador
    // Detectar cuándo ha salido de mi área de efecto el jugador

    #region ATTRIBUTES

    // Daño que hace esta trampa
    [SerializeField]
    [Range(1, 3)]
    int coinsLost = 1;

    // Frecuencia con que hace daño esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 2;

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
        player.EarnMoney(-coinsLost);

        // Esperamos la frecuencia indicada en la variable
        yield return new WaitForSeconds(trapFrequency);

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
