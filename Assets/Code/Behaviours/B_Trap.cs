using System.Collections;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES

    //daño que hace esta trampa
    //frecuencia con la que hace daño

    public enum TrapType
    {
        trap1,
        trap2,
        trap3,
    }

    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;

    bool playerIsInsideArea = false;


    #endregion

    #region METHODS

    //detectar cuando ha entrado el playe rne su area de efecto
    //detectar cuando ha salido el player
    //dañar al player mientars este dentro

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>())); //invocar una subrutina facilitando en parametros el componente del player
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    IEnumerator HurtPlayer(B_CharacterController player)
    {
        player.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        if (playerIsInsideArea)
        {
            StartCoroutine(HurtPlayer(player));
        }
    }

    #endregion
}
