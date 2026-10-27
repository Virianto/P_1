using UnityEngine;

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
        // Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerReceivedDamage()
    {
        // Informar al canvas de que debe actualizar su Slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }
    public void PlayerReceivedLife()
    {
        // Informar al canvas de que debe actualizar su Slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        // Indicar al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.EnableControlButton(controlPlatform, trapObject);
    }

    public void DisableTrapButton() 
    {
        gameplayCanvas.DisableControlButton();
    }


    public void FinishGame()
    {        
        gameplayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
