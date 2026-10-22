using UnityEngine;

public class B_LifeRestorer : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] int lifeToRestore = 5;
    #endregion

    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController2 player = other.GetComponent<B_CharacterController2>();
        if (player.lifePointsLeft != 20)
        {
            player.RestoreLife(lifeToRestore);
        }
        
        gameObject.SetActive(false);
    }

    #endregion
}
