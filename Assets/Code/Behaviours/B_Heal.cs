using System.Collections;
using UnityEngine;

public class B_Heal : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem healParticles;

    [SerializeField]
    GameObject healBody;


    [SerializeField]
    [Range(0, 10)]
    int healedLife = 5;

    bool playerGotHealed = false;
    #endregion



    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Va a reproducir un sonido de recolección
        coinAudioSource.PlayOneShot(coinAudioSource.clip);

        // Va a emitir unas partículas
        healParticles.Emit(50);

        // Desactivar sphere collider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        // Desactivar el renderer del hijo para que el jugador deje de ver la moneda
        // GetComponentInChildren<Renderer>().enabled = false;
        healBody.SetActive(false);

        if (other.GetComponent<B_CharacterController>()!=null)
        {
            HealPlayer(other.GetComponent<B_CharacterController>());

        }
    }

    public void HealPlayer(B_CharacterController player)
    {
        // Código que se ejecuta de inmediato al invocar la subrutina
        // Dañar al jugador

        player.HealPlayer(healedLife);

        //Debug.Log("El jugdor está recibiendo daño");
        //Debug.Log("Se llama {0}", player.name);

       
    }



    #endregion
}
