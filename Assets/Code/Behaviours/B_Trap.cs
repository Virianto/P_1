
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

        // Invocar una subrutina facilitando en prámetro el componente del palyer
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));

        // Decirle a Unity que lo que viene a continuación es un método temporizado, tiene que llevar específico si tiene o no tiene parámetros


    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuando ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");

    }

    // Declarar un método con gestión de tiempo para dañara al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // Código que se ejecuta de inmediato al invocar la subrutina
        // Dañar al jugador
        player.TakeDamage(trapDamage);

        //Debug.Log("El jugdor está recibiendo daño");
        //Debug.Log("Se llama {0}", player.name);


        yield return new WaitForSeconds(trapFrequencyDamage);

        //Debug.Log("Ya ha pasado la espera, hacer otra cosa");
        //Debug.Log("Sigo sabiendo su nombre: {0}", player.name);


        // Código que se ejecuta tras la espera indicada (en este caso en tiempo)
        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar esta subrutina
            StartCoroutine(HurtPlayer(player));

        }



    }

    // Va a dañar al jugador mientras esté dentro



    #endregion

}
