using UnityEngine;

public class B_SuperCoin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource superCoinAudioSource;

    [SerializeField]
    ParticleSystem superCoinParticles;

    [SerializeField]
    GameObject superCoinBody;




    #endregion



    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Va a reproducir un sonido de recolección
        superCoinAudioSource.PlayOneShot(superCoinAudioSource.clip);

        // Va a emitir unas partículas
        superCoinParticles.Emit(500);

        // Desactivar sphere collider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        // Desactivar el renderer del hijo para que el jugador deje de ver la moneda
         GetComponentInChildren<Renderer>(superCoinBody).enabled = false;
        //superCoinBody.SetActive(false);

    }



    #endregion
    }
