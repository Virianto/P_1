using System.Collections;
using UnityEngine;

public class B_Money_Trap : MonoBehaviour
{
    // Monedas que pierde
    [SerializeField]
    [Range(0, 3)]
    int coinsLost = 1;

    // Frecuencia con que roba dinero
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencySteal = 1;

    bool playerIsInsideArea = false;

    //Quitarle monedas al jugador mientras esté dentro
    void OnTriggerEnter(Collider other)
    {
        //Detecta cuándo he entrado en contacto con el jugador
        playerIsInsideArea = true;

        if (!CompareTag("Coin"))
            StartCoroutine(CoinManager(other.GetComponent<B_CharacterController>()));
        else
            StartCoroutine(CoinManager(other.GetComponent<B_CharacterController>(), false));

    }

    IEnumerator CoinManager(B_CharacterController player, bool steal = true)
    {
        //Le pongo un - delante porque el método suma unicamente
        if (steal)
            player.EarnMoney(-coinsLost);
        else
            player.EarnMoney(coinsLost);

        //Esperamos la frecuencia indicada en la variable
        yield return new WaitForSeconds(trapFrequencySteal);

        //Comprobamos si sigue dentro para seguir robando
        if (playerIsInsideArea)
        {
            StartCoroutine(CoinManager(player, steal));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Detectar cuándo ha salido de mi área de efecto
        playerIsInsideArea = false;
    }
}
