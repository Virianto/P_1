using System;
using UnityEngine;

//// Un enumerado puede vivir fuera de cualquier clase de mi código
//public enum CoinType
//{
//    Yellow,
//    Blue,
//    Green
//}

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    public CoinType coinType;
    
    // Un enumerado puede vivir fuera de cualquier clase de mi código
    public enum CoinType
    {
        Yellow,
        Blue,
        Green
    }

    M_GameManager2 gameManager;

    float lifeTime = 1;
    AudioSource coinAudioSource;
    ParticleSystem coin_PS;
    GameObject coinBody;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();
        player.canCollectYellowCoins = true; //Dejo esto por defecto para los demás ejercicios

        // CASO 1: MONEDAS AMARILLAS
        if (player.canCollectYellowCoins && (coinType == CoinType.Yellow))
        {
            Debug.Log("Moneda AMARILLA recogida");
            //player.totalYellowCoinsCollected += 1;
            player.EarnMoney(name.Contains("Super") ? 5 : 1);

            // Lanzar un sonido de recolección
            // Desactivar la moneda 
            coinAudioSource = GetComponentInChildren<AudioSource>();
            coinAudioSource.PlayOneShot(coinAudioSource.clip);
            // Va a emitir unas partículas de despedida
            coin_PS = GetComponentInChildren<ParticleSystem>();
            coin_PS.Emit(50);
            // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
            GetComponent<Collider>().enabled = false;
            // Desactivar el hijo para que el jugador deje de ver la moneda
            GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);
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

    public void InitializeCoin(M_GameManager2 manager, Vector3 newPos, bool isSuper)
    {
        gameManager = manager;
        transform.position = newPos;
        //isSuper = true;
        if (isSuper)
        {
            name = $"{name}Super";
            transform.localScale = new Vector3(3, transform.localScale.y * 3, 3);
        }
        //StartCoroutine();
    }

    #endregion
}
