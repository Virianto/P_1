using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class M_GameManager : MonoBehaviour
{
    //Referencia al player
    //Referencia a la UI de escena

    public B_CharacterController player;
    public UI_GameOverCanvas gameOverCanvas;
    public UI_GameOverCanvas gameplayCanvas;
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

    public void EnableTrapButton(GameObject trapObject)
    {
        //Indicar al Canvas que active el bot�n
        gameplayCanvas.EnableControlButton(trapObject);
    }

    public void DisableTrapButton()
    {
        gameplayCanvas.DisableControlButton();
    }
}
