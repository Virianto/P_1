using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_gameover : MonoBehaviour
{
    #region ATTRIBUTES

    public UI_GameOverCanvas gameOverCanvas;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("npc"))
        {
            SceneManager.LoadScene(0);
        }
        
    }

    #endregion
}

