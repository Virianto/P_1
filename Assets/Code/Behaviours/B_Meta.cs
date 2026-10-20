using UnityEngine;

public class B_Meta : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    ParticleSystem fireworks_PS;

    KeyCode finishGameKey = KeyCode.Y;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController check = other.GetComponent<B_CharacterController>();
        if (check.metaYellow==true && check.metaOrange==true && check.metadBlue==true)
        {
            gameManager.FinishGame();
            fireworks_PS.Play();
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit()
    {
        
    }

    void ShowLevelCompleteMessage()
    {
    }

    #endregion
}
