using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    public B_gameover goal;

    public UI_GameOverCanvas gameOverCanvas;


    #endregion

    #region METHODS

    public void NewCoinCollected()
    {
        //decirle al canvas que modifique su texto de contador facilitandole el valor desde player
        gameOverCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerReceivedDamage() //informar al canvas
    {
        gameOverCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void MoneyOnPlayer()
    {
        gameOverCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerHealed() //informar al canvas
    {
        gameOverCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        gameOverCanvas.EnableControlButton(controlPlatform, trapObject);
    }

    public void EnableDynamicTrapButton(GameObject controlPlatform, GameObject B_DynamicObstacle)
    {
        //gameOverCanvas.EnableObstacleControlButton(ctrlPlatform, dynamicObstacle);
    }

    public void DisableTrapButton()
    {
        gameOverCanvas.DisableControlButton();
    }

    public void FinishGame()
    {        
        gameOverCanvas.gameObject.SetActive(true);
    }

    #endregion
}
