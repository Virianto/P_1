using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager de la clase
/// con dos monedas (normal, super)
/// se ocupa de eliminar moneda cuando se recoja
/// En la escena, habrá plataforma que cambie de tipo las monedas (al tipo contrario)
/// </summary>
public class M_GameManager2 : MonoBehaviour
{
    #region ATTRIBUTES
    public UI_GameHudCanvas gameplayCanvas;

    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    B_CharacterController player;

    //[SerializeField]
    //B_Coin coin;

    [SerializeField]
    KeyCode spawnKey = KeyCode.G;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    List<B_Coin> coinList = new();
    #endregion

    #region METHODS
    private void Update()
    {
        if (Input.GetKeyDown(spawnKey)) {
            bool isSuperCoin = Random.value > 0.7 ? true : false;

            float rangoX = Random.Range(-horizontalXRange, horizontalXRange);
            float rangoZ = Random.Range(-horizontalZRange, horizontalZRange);

            Vector3 newRandomPosition = new Vector3(rangoX, 2.5f, rangoZ);

            B_Coin newCoin = Instantiate(coinPrefab).GetComponent<B_Coin>();
            
            coinList.Add(newCoin);
            newCoin.InitializeCoin(this, newRandomPosition, isSuperCoin);
        }
    }

    public void NewCoinCollected()
    {
        // Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalYellowCoinsCollected);
    }
    #endregion
}
