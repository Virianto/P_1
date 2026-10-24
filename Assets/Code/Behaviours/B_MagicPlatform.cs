using System.Collections;
using UnityEngine;

public class B_MagicPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    // Monedas que quita esta trampa
    [SerializeField]
    [Range(1, 3)]
    int coinsGain = 1;

    // Frecuencia con que quita monedas esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequency = 1;

    bool playerIsInsideArea = false;
    [SerializeField] ParticleSystem rainCoins;

    [SerializeField] Light rainLight;

    #endregion






    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;

        StartCoroutine(StealCoinsToPlayer(other.GetComponent<B_CharacterController>()));
    }

    IEnumerator StealCoinsToPlayer(B_CharacterController player)
    {
        // Restamos monedas
        player.EarnMoney(coinsGain);
        rainCoins.Play();
        rainLight.GetComponent<Light>().intensity = 10;

        // Esperamos la frecuencia inficada en la variable
        yield return new WaitForSeconds(trapFrequency);

        // Comprobamos si el player sigue dentro del área
        if (playerIsInsideArea)
        {
            StartCoroutine(StealCoinsToPlayer(player));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;

        rainCoins.Stop();
        rainLight.GetComponent<Light>().intensity = 0;
    }

    #endregion
}
