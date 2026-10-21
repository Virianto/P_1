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

    //Detectar cuándo ha entrado el jugador en su área de efecto
    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        Debug.Log("El jugador ha entrado");
        //Invocar una subrutina facilitando en parámetros el componente del player
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
    }
    //Va a dañar al jugador mientras esté dentro

    
    //Detectar cuándo ha salido el jugador de su área de efecto
    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");
    }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        //Dañar al jugador
        Debug.LogFormat("Se llama {0}", player.name);
        yield return new WaitForSeconds(trapFrequencyDamage);
        Debug.LogFormat("Su nombre sigue siendo {0}", player.name);

        //Comprobar si el jugador sigue estando dentro

        //Volver a llma esta subtrama
    }
    #endregion
}
