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
    public AudioSource damageAudioSource;

    bool enemyIsInsideArea = false;

    #endregion





    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<B_CharacterController>() != null)
        {
            // Detectar cuándo ha entrado el jugador en su área de efecto
            playerIsInsideArea = true;

            // Invocar una subrutina facilitando en parámetros el componente del player
            StartCoroutine(HurtPlayer(other.GetComponent<B_CharacterController>()));
        }

        if (other.GetComponent<B_CharacterController>() != null)
        {
            // Detectar cuándo ha entrado un enemigo en su área de efecto
            enemyIsInsideArea = true;

            // Invocar una subrutina facilitando en parámetros el componente del player
            StartCoroutine(HurtEnemy(other.GetComponent<C_SpawnEnemy>()));
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
        enemyIsInsideArea = false;
    }

    // Declarar un método con gestión de tiempo para dañar al jugador
    IEnumerator HurtPlayer(B_CharacterController player)
    {
        // Dañar al jugador
        player.TakeDamage(trapDamage);
        damageAudioSource.Play();

        yield return new WaitForSeconds(trapFrequencyDamage);

        // Comprobar si el jugador sigue estando dentro
        if (playerIsInsideArea)
        {
            // Volver a llamar a esta subrutina
            StartCoroutine(HurtPlayer(player));
        }

    }

    IEnumerator HurtEnemy(C_SpawnEnemy enemy)
    {
        // Dañar al enemigo
        enemy.TakeDamage(trapDamage);

        yield return new WaitForSeconds(trapFrequencyDamage);

        // Comprobar si el enemigo sigue estando dentro
        if (enemyIsInsideArea)
        {
            // Volver a llamar a esta subrutina
            StartCoroutine(HurtEnemy(enemy));
        }

    }

    #endregion
}
