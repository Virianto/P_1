using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES

    // Daño que hace esta trampa
    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;

    // Frecuencia con que hace daño esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;

    bool playerIsInsideArea = false;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;
        Debug.Log("El jugador ha entrado");

        //Invocar una subrutina, facilitando en parámetros el componente del player
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");
    }

    //método con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        //Dañar al jugador
        player.TakeDamage(trapDamage);

        Debug.Log("Dañar al jugador antes de la espera");
        Debug.Log($"Se llama {player.name}");

        yield return new WaitForSeconds(trapFrequencyDamage);

        //Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            //Volver a llamar a esta subrutina
            StartCoroutine(HurtPlayer(player));
        }

        Debug.Log("Ya ha pasado la esperas, hacer otra cosa");
        Debug.Log($"Sigue llamandose {player.name}");
    }

    #endregion
}
