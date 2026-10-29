using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_Goal : MonoBehaviour
{
    #region ATTRIBUTES
    public M_GameManager gameManager;


    #endregion


    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }


    #endregion
}
