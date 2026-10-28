using UnityEngine;
using UnityEngine.SceneManagement;

public class B_FinalGoal : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;
    public M_AgentsInput agentsManager;

    //[SerializeField]
    //KeyCode finishGameKey = KeyCode.F;

    public B_CharacterController player;
    public B_AngeyAgent agent;

    bool playerCanFinishGame = false;
    public bool agentCanFinishGame = false;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        playerCanFinishGame = true;
        agentCanFinishGame = true;
    }

    void Update()
    {
        if (playerCanFinishGame == true || agentCanFinishGame == true || player.lifePointsLeft == 0)
        {
           
                // Comunicar al manager que se quiere finalizar
                SceneManager.LoadScene(0);
                //ShowLevelCompletionMessage();
       
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    playerCanFinishGame = false;
    //}

    //void ShowLevelCompletionMessage()
    //{
    //    // Creo un registro temporal de todas las monedas que ha recogido el jugador
    //    int totalCoinsCollected = player.totalCoinsCollected;

    //    // Si tiene todas las monedas, le felicito
        
    //    if (totalCoinsCollected >= 29) 
    //    {
    //        // Este bloque solamente se ejecuta si el IF sale TRUE
    //        Debug.Log("¡¡ FELICIDADES CRACK !!");
    //        SceneManager.LoadScene(0);
    //    }
    //    else
    //    {
    //        // Este bloque solamente se ejecuta si el IF sale FALSE
    //        Debug.Log("Todavía te faltan monedas");
    //    }

    }

    #endregion
