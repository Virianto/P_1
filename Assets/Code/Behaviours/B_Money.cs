using System.Collections;
using UnityEngine;

public class B_Money : MonoBehaviour
{
    // Detectar cuándo ha entrado el jugador
    // Quitarle monedas al jugador
    // Detectar cuándo ha salido el jugador

    #region ATTRIBUTES
    // Daño q hace la trampa
    [SerializeField]
    [Range(1, 5)]
    int coinLost = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrecuency = 1;

    bool playerIsInsideArea = false;

    #endregion

    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;

        // Invocar una subrutina facilitando por parámetros el componente del player
        StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));
    }

    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {
        //Le pongo un '-' delante a la variable porque el método suma únicamente
        player.EarnMoney(-coinLost);

        yield return new WaitForSeconds(trapFrecuency);
        
        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a la subrutina
            StartCoroutine(StealCoinsToPlayer(player));
        }
    }


    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    #endregion
}
