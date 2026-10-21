using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES
    // Daño q hace la trampa
    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrecuencyDamage = 1;

    bool playerIsInsideArea = false;

    // Frecuencia con q hace daño la trampa



    #endregion


    #region METHODS
    // Detectar cuándo ha entrado el jugador en el área de efecto
    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        Debug.Log("El jugador ha entrado");

        // Invocar una subrutina facilitando por parámetros el componente del player
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }

    // Declarar un método (subrutina) con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // dañar al jugador
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrecuencyDamage);
        
        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a la subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }


    // Detectar cuándo ha salido el jugador en el área de efecto
    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");
    }


    #endregion
}
