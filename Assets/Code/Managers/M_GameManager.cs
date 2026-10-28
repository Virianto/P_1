using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class M_GameManager : MonoBehaviour
{
    //Referencia al player
    //Referencia a la UI de escena

    public B_CharacterController player;
    public UI_GameOverCanvas2 gameOverCanvas;
    public UI_GameHudCanvas gameplayCanvas;
    //public B_Meta meta;

    public void FinishGame()
    {
        //Método publico en el que se reciba información para rellenar el canvas de Game Over
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void PlayerIULife()
    {
        //Informar al Canvas de que debe actualizar slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        //Indicar al Canvas que active el botón
        gameplayCanvas.EnableControlButton(controlPlatform, trapObject);
    }

    public void DisableTrapButton()
    {
        gameplayCanvas.DisableControlButton();
    }

    //public void EnableDynamicTrapButton(GameObject controlPlatform, GameObject trapObject)
    //{
    //    //Indicar al Canvas que active el botón
    //    gameplayCanvas.EnableControlButton(controlPlatform, dynamicObstacle);
    //}

    //public void DisableDynamicTrapButton()
    //{
    //    gameplayCanvas.DisableControlButton();
    //}

    public void NewCoinCollected()
    {
        // Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalYellowCoinsCollected);
    }
}
