using UnityEngine;

public class B_FinalGoal : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    KeyCode finishGameKey = KeyCode.F;

    B_CharacterController player;

    bool playerCanFinishGame = false;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        playerCanFinishGame = true;
        player = other.GetComponent<B_CharacterController>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(finishGameKey))
        //{
        //    if (playerCanFinishGame) 
        //    {
        //        // Comunicar al manager que se quiere finalizar
        //        gameManager.FinishGame();
        //        //ShowLevelCompletionMessage();
        //    }
        //}                        
    }

    void OnTriggerExit(Collider other)
    {
        playerCanFinishGame = false;
    }

    void ShowLevelCompletionMessage()
    {
        // Creo un registro temporal de todas las monedas que ha recogido el jugador
        int totalCoinsCollected = player.totalCoinsCollected;

        // Si tiene todas las monedas, le felicito
        
        if (totalCoinsCollected >= 6) 
        {
            // Este bloque solamente se ejecuta si el IF sale TRUE
            Debug.Log("¡¡ FELICIDADES CRACK !!");
        }
        else
        {
            // Este bloque solamente se ejecuta si el IF sale FALSE
            Debug.Log("Todavía te faltan monedas");
        }

    }

    #endregion
}
