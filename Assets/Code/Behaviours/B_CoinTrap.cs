using System.Collections;
using UnityEngine;

public class B_CoinTrap : MonoBehaviour
{

    //Detectar cuándo ha entrado el jugaodr

    //Quitarle monedas mientras esté

    //Detectar cuándo ha salido del área

    #region ATTRIBUTES
    // Daño que hace esta trampa 
    [SerializeField]
    [Range(1, 3)]
    int coinsGiven = 1;
    // Frecuencia con que hace daño esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 1;

    bool playerIsInsideArea = false;

    [SerializeField]
    AudioSource trapAudioSource;

    [SerializeField]
    ParticleSystem trapPatricles;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;

        //Invocar una subrutina facilitando en parámetros el componente del player
        StartCoroutine(EarnMoney(other.GetComponent<B_CharacterController>()));
    }
    //Va a dañar al jugador mientras esté dentro


    //Detectar cuándo ha salido el jugador de su área de efecto
    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    IEnumerator EarnMoney(B_CharacterController player)
    {
        //Dañar al jugador
        player.EarnMoney(coinsGiven);
        //trapAudioSource.PlayOneShot(trapAudioSource.clip);
        trapPatricles.Emit(50);


        yield return new WaitForSeconds(trapFrequency);

        //Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            StartCoroutine(EarnMoney(player));
        }



        //Volver a llma esta subtrama
    }
    #endregion


}
