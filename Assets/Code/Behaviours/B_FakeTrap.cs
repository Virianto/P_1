using TMPro;
using UnityEngine;

public class B_FakeTrap : MonoBehaviour
{
    #region ATTRIBUTES

    public B_CharacterController player;

    public M_GameManager gameManager;

    [SerializeField]
    TMP_Text Text;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        player.totalCoinsCollected = 0;
        gameManager.NewCoinsCollected();
        Text.text = "Te has quedado sin monedas";
    }

    #endregion
}
