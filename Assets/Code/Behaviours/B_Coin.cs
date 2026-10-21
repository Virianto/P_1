using UnityEngine;

// Un enumerado puede vivir fuera de cualquier clase de mi código
public enum CoinType
{
    Yellow,
    Blue,
    Green
}

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    /* detectar la colision con player
     * reproducir sonido de recolleccion
     * emitir particulas de despedida
     * desaparecer
     * */

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticleSystem;

    [SerializeField]



    // cuantas monedas ha recogido mi player

    public CoinType coinType;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        coinAudioSource.PlayOneShot(coinAudioSource.clip); //emite el sonido al ser to

        coinParticleSystem.Emit(50); //emite particulas al ser tocado

        //GetComponent<Collider>().enabled = false;

        //coinBody.SetActive(false); //desactivo el collider de la coin para que no la recoja mas veces
    }

    #endregion
}
