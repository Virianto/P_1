using UnityEngine;

// Un enumerado puede vivir fuera de cualquier clase de mi código
public enum CoinType_V
{
    Yellow,
    Blue,
    Green
}

public class B_Coin_V : MonoBehaviour
{
    #region ATTRIBUTES

    public CoinType coinType;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
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
    }

    #endregion
}
