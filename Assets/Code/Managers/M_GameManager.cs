using UnityEngine;
using UnityEngine.SceneManagement;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController2 player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gameplayCanvas;

    #endregion

    #region METHODS
    public void NewCoinCollector()
    {
        //decirle al canvas que modifique su texto de contador
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }
    public void PlayerReceiveDamage()
    {
        //informar al canvas de que debe actualizar su slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        // Indicar al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.EnableControlButton(controlPlatform, trapObject);
        Debug.Log("EnableTrapButton");
    }

    public void DisableTrapButton()
    {
        // Indicar al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.DisableControlButton();
        Debug.Log("DisableTrapButton");
    }
    public void FinishGame()
    {
        //gameplayCanvas.gameObject.SetActive(true);
        SceneManager.LoadScene("CharacterCanvas");
    }

    public void EnableTrapDoor(GameObject controlPlatform, B_TrapDoor trapDoorObject)
    {
        // Indicar al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.EnableTrapDoor(controlPlatform, trapDoorObject);
        Debug.Log("EnableTrapDoor in GameManager");
    }

    #endregion
}
