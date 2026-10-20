using UnityEngine;

public class M_GameManager : MonoBehaviour
{

    public BasicPlayer player;
    public UI_GameOverCanvas gameOverCanvas;
    public B_CakeEnd end;

    public void finishGame()
    {
        gameOverCanvas.gameObject.SetActive(true);
        player.enabled = false;

    }



}
