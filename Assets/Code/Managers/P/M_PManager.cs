using UnityEngine;
using UnityEngine.SceneManagement;

public class M_PManager : MonoBehaviour
{
    #region ATTRIBUTES
    public B_CoinCharacter player;
    public UI_PGameplayCanvas gameplayCanvas;

    #endregion

    #region METHODS
    public void NewCoinCollected()
    {
        //Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void TimeEarned()
    {
        gameplayCanvas.GainTime();
    }
    #endregion
}
