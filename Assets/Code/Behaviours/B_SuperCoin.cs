using UnityEngine;

public class B_SuperCoin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticles;

    //[SerializeField]
    //GameObject coinBody;


    // ¿Cuántas monedas ha recogido mi jugador?
    #endregion


    #region METHODS

    // Detectar la colisión con el jugador (SOLAMENTE EL JUGADOR)

    private void OnTriggerEnter(Collider other)
    {
        // Reproducir sonido de reproducción
        coinAudioSource.PlayOneShot(coinAudioSource.clip);

        // Emitir partículas de despedida
        coinParticles.Emit(80);

        // Desactivar el spereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        // desactivar el render del hijo para q el jugador deje de ver la moneda

        GetComponentInChildren<Renderer>().enabled = false;       //UNA MANERA DE HACERLO, SI NO ME PILLARA EL OBJETO HACER [SerializeField]GameObject coinBody; Y LO SIGUIENTE:
        //coinBody.SetActive(false);
    }


    #endregion
}
