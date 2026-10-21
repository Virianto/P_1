using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    public GameObject trapGameObject;

    #endregion
    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(trapGameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }

    #endregion
}
