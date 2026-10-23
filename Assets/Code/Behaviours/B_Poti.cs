using System.Collections;
using UnityEngine;

public class B_Poti : MonoBehaviour
{
    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem potiParticles;

    [SerializeField]
    GameObject potiBody;

    bool playerIsInsideArea = false;
    
    // Frecuencia curación objeto
    [SerializeField]
    [Range(0.5f, 3)]
    float healFrequency = 1;
    int healValue = 1;

    void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de recolección
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        potiParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de verla
        potiBody.SetActive(false);
        
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;
        //Debug.Log("El jugador ha entrado");

        //Invocar una subrutina, facilitando en parámetros el componente del player
        StartCoroutine(HealPlayer(other.GetComponent<B_CharacterController>()));
    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
        Debug.Log("El jugador ha salido");
    }

    IEnumerator HealPlayer(B_CharacterController player)
    {
        // Curar al jugador
        player.HealLife(healValue);

        Debug.Log("Curar al jugador antes de la espera");
        Debug.Log($"Se llama {player.name}");

        yield return new WaitForSeconds(healFrequency);

        ////Comprobar si el jugador sigue estando dentro
        //if (playerIsInsideArea)
        //{
        //    //Volver a llamar a esta subrutina
        //    StartCoroutine(HealPlayer(player));
        //}
    }

}
