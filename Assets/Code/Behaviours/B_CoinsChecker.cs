using UnityEngine;

public class B_CoinsChecker : MonoBehaviour
{
    #region ATTRIBUTES

    // Contador de monedas (límite, o el máximo, o lo que sea)
    public int targetYellowCoins = 2;
    public int targetBlueCoins = 2;
    public int targetGreenCoins = 2;

    // Referencia a un sistema de partículas
    [SerializeField]
    ParticleSystem confetti;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
       // Me guardo referencia al player
       //B_CharacterController player = other.GetComponent<B_CharacterController>();

       // // CASO 1: Compruebo AMARILLAS
       // if (player.totalCoinsCollected >= targetYellowCoins)
       // {
       //     Debug.Log("El jugador tiene la cantidad esperada de monedas AMARILLAS");
       //     // Lanzar partículas si es el caso
       // }

       // // CASO 2: Compruebo AZULES
       // if (player.totalBlueCoinsCollected >= targetBlueCoins)
       // {
       //     Debug.Log("El jugador tiene la cantidad esperada de monedas AZULES");
       //     // Lanzar partículas si es el caso
       // }

       // // CASO 3: Compruebo VERDES
       // if (player.totalGreenCoinsCollected >= targetGreenCoins)
       // {
       //     Debug.Log("El jugador tiene la cantidad esperada de monedas VERDES");
       //     // Lanzar partículas si es el caso
       // }
    }    

    #endregion
}
