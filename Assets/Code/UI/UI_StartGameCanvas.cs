using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartGameCanvas : MonoBehaviour
{    
    #region ATTRIBUTES

    [SerializeField]
    Button startGameButton;

    #endregion

    #region METHODS

    void Awake()
    {
        startGameButton.onClick.AddListener(LaunchGame);
    }

    public void LaunchGame()
    {        
        SceneManager.LoadScene(1);
    }    

    #endregion
}
