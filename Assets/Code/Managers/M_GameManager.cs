using UnityEngine;
using UnityEngine.SceneManagement;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gameplayCanvas;

    #endregion

    #region METHODS

    public void NewCoinCollected()
    {
        // Decirle al canvas q modifique su texto de contador
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerReceiveDamage()
    {
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
        
        if (player.lifePointsLeft <= 0)
        {
            gameplayCanvas.ResetGame();
        }
    }

    public void NewLifeCollected()
    {
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlataform, GameObject trapObject)
    {
        // Indicar al canvas q debe activar el botón para poder interactuar
        gameplayCanvas.EnableControlButton(controlPlataform, trapObject);
    }

    public void DisableTrapButton()
    {
        // Indicar al canvas q debe activar el botón para poder interactuar
        gameplayCanvas.DisableControlButton();
    }

    public void FinishGame()
    {        
        gameplayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
