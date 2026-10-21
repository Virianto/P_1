using UnityEngine;

public class B_BonusLife : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 5)]
    int regenerateLife = 5;

    public B_CharacterController player;

    public M_GameManager gameManager;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        if(player.lifePointsLeft < 20)
        {
            player.lifePointsLeft += regenerateLife;
            gameManager.PlayerUpdateLive();
            if (player.lifePointsLeft > 20)
            gameManager.PlayerUpdateLive();
            Debug.Log("mi vida es: " +  player.lifePointsLeft);
            {
                player.lifePointsLeft = 20;
                gameManager.PlayerUpdateLive();
                Debug.Log("mi vida  es: " + player.lifePointsLeft);
            }
        }
    }

    #endregion
    }
