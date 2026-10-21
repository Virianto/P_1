using Unity.VisualScripting;
using UnityEngine;

// Un enumerado puede vivir fuera de cualquier clase de mi código
/*public enum CoinType
{
    Yellow,
    Blue,
    Green
}*/

public class B_Coin : MonoBehaviour

{
    #region ATTRIBUTES

    // Detectar la colisión con el jugador (SOLAMENTE EL JUGADOR)

    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObject coinBody;

    //public CoinType coinType;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Va a reproducir un sonido de recolección
        coinAudioSource.PlayOneShot(coinAudioSource.clip);

        // Va a emitir unas partículas
        coinParticles.Emit(50);

        // Desactivar sphere collider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;

        // Desactivar el renderer del hijo para que el jugador deje de ver la moneda
        // GetComponentInChildren<Renderer>().enabled = false;
        coinBody.SetActive(false);

    }

    /*void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // CASO 1: MONEDAS AMARILLAS
        if (player.canCollectYellowCoins && (coinType == CoinType.Yellow))
        {
            Debug.Log("Moneda AMARILLA recogida");
            player.totalYellowCoinsCollected += 1;

            // Lanzar un sonido de recolección
            // Desactivar la moneda 
        }

        // CASO 2: MONEDAS AZULES
        if(player.canCollectBlueCoins && (coinType == CoinType.Blue))
        {
            Debug.Log("Moneda AZUL recogida");
            player.totalBlueCoinsCollected += 1;            
        }

        // CASO 3: MONEDAS VERDES
        if (player.canCollectGreenCoins && (coinType == CoinType.Green))
        {
            Debug.Log("Moneda VERDE recogida");
            player.totalGreenCoinsCollected += 1;
        }
    }*/

    #endregion
}
