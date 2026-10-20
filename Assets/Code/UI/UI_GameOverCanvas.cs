using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_GameOverCanvas : MonoBehaviour
{
    public M_GameManager gameManager;


    [SerializeField] Button TryAgainButton;


    void Awake()
    {
        TryAgainButton.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }

}
