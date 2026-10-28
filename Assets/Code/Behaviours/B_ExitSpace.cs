using UnityEngine;


/// <summary>
/// Cuando un objeto llegue a la salida se acaba el juego
/// </summary>
public class B_ExitSpace : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    UI_GameOverCanvas gameCanvas;

    #endregion






    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        gameCanvas.ResetGame();
    }
    #endregion
}