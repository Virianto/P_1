using UnityEngine;

/// <summary>
/// Manager de TODOS los anillos
/// Crea instancias de anillos cada X (Variable)
/// y decide el tipo en InitializeRing()
/// Reemplazar esto por los c_...triggers, ya solo hay eventos para vida etc
/// </summary>
public class B_HoveringRing : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_RingManager.RingType ringType;
    //enum RingType
    //{
    //    speedRing,
    //    coinRing,
    //    lifeRing,
    //    timeRing
    //}

    [SerializeField]
    M_RingManager manager;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (ringType)
        {
            //case RingType.speedRing:
            //    manager.ModifyPlayerSpeed(2);
            //    break;
            //case RingType.coinRing:
            //    manager.EarnMoney(1);
            //    break;
            //case RingType.timeRing:
            //    manager.ModifyPlayerTime(10);
            //    break;
            //case RingType.lifeRing:
            //    manager.ModifyPlayerLife(-2.5f);
            //    break;
        }
    }

    //public void ModifyPlayerSpeed(float amount)
    //{
    //    speed += amount;
    //    M_FlightSimulator.Instance.PlayerSpeedChanged(speed);
    //}

    //public void ModifyPlayerLife(float amount)
    //{
    //    lifePointsLeft += amount;
    //    M_FlightSimulator.Instance.PlayerLifeChanged(lifePointsLeft / maxLifePoints);
    //}

    //public void EarnMoney(int moneyAmount)
    //{
    //    //totalYellowCoinsCollected += moneyAmount;
    //    totalYellowCoinsCollected = Mathf.Clamp(totalYellowCoinsCollected + moneyAmount, 0, 100);
    //    gameManager.NewCoinCollected();
    //}

    #endregion
}
