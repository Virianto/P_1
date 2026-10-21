using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    /*Detectar cuando ha entrado el jugador en su area de efecto
     Daña al jugador mientras este dentro
     Cuando ha salido el jugador*/
    #region ATTRIBUTES
    //daño trampa
    [SerializeField][Range(0, 10)] int trapDamage = 1;

    //frecuencia daño trampa
    [SerializeField][Range(0.5f, 3)] float trapFrequency = 1;

    bool playerIsInsideArea = false;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        Debug.Log("El jugador ha entrado");
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController2>()));
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");
    }

    IEnumerator HurtPlayer(B_CharacterController2 player) //sustituye a la palabra void -> se ejecuta de inmediato al invocar la subrutina
    {
        //daña al jugador
        //Debug.LogFormat("se llama {0}", player.name);
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequency);
        //el código de dentro de ejecuta trnas la espera indicado.
        //Debug.LogFormat("sigo sabiendo su nombre {0}", player.name);
        if (playerIsInsideArea)
        {
            //se vuelve a llamar a la subrutina
            StartCoroutine(HurtPlayer(player));
        }
    }
    #endregion
}
