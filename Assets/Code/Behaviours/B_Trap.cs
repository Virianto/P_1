using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES

    // Daño que hace la trampa
    [SerializeField] [Range(0, 10)] int trapDamage = 1;
    // Frecuencia con que hace daño esta trampa
    [SerializeField] [Range(0.5f, 3)] float trapFrequencyDamage = 1;

    bool playerIsInsideArea = false;

    #endregion





    #region METHODS

    // Detectar cuándo ha entrado el jugador en su área de efecto
    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        Debug.LogFormat("Se llama {0}, player.name");

        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }

    // Detectar cuándo ha salido el jugador de su área de efecto
    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        Debug.Log("El judador ha salido");
    }

    // Declarar un método con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController.player)
    {
        // Dañar al jugador
        Debug.Log("Dañando al jugador");

        yield return new WaitForSeconds(trapFrequencyDamage);

        // Comprobar si el jugador sigue dentro

        // Volver a llamar a la subrutina

    }

    #endregion

}
