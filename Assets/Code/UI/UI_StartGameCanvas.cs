using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartGameCanvas : MonoBehaviour
{    
    [SerializeField]
    Button startGameButton;


    void Awake()
    {
        startGameButton.onClick.AddListener(LaunchGame);
    }

    public void LaunchGame()
    {        
        SceneManager.LoadScene(1);
    }    

}
