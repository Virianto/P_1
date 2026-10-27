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
        //Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    
    public void PlayerReceivedDamage()
    {
        //Informar al canvas de que debe actualizar su slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        //Indicar al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.EnableControlButton(controlPlatform, trapObject);
    }
    public void EnableObstacleTrapButton(GameObject obstaclePlatform, GameObject trapObject)
    {
        gameplayCanvas.EnableObstacleControlButton(obstaclePlatform, trapObject);
    }
    public void EnableCoinTrapButton(GameObject coinControlPlatform, GameObject trapObject)
    {
        gameplayCanvas.EnableCoinTrapButton(coinControlPlatform, trapObject);
    }
    public void DisableObstacleTrapButton()
    {
        gameplayCanvas.DisableObstacleTrapButton();
    }
    public void DisableCoinTrapButton()
    {
        gameplayCanvas.DisableCoinTrapButton();
    }
    public void DisableTrapButton()
    {
        gameplayCanvas.DisableControlButton();
    }
    public void EnableCoinTrap(GameObject coinControlPlatform)
    {
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }
    public void PlayerGainsLife()
    {
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }
    //public void FinishGame()
    //{


    //}

    #endregion
}
