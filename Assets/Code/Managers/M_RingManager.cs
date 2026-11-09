using UnityEngine;

/// <summary>
/// Aquí la descripcion de qué hace la clase
/// </summary>
public class M_RingManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_FlightSimulator globalManager;
    B_PlayerPlane player;

    public enum RingType
    {
        speedRing,
        coinRing,
        lifeRing,
        timeRing
    }

    #endregion

    #region METHODS

    private void Start()
    {
        player = globalManager.player;
    }

    public void ModifyPlayerSpeed(float amount)
    {
        player.speed += amount;
        M_FlightSimulator.Instance.PlayerSpeedChanged(player.speed);
    }

    public void ModifyPlayerLife(float amount)
    {
        player.lifePointsLeft += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(player.lifePointsLeft/player.maxLifePoints);
    }

    public void ModifyPlayerTime(float time)
    {
        //globalManager.gameTimeLeft += time;
        M_FlightSimulator.Instance.PlayerTimeChanged(time);
    }

    public void EarnMoney(int moneyAmount)
    {
        //totalYellowCoinsCollected += moneyAmount;
        player.totalYellowCoinsCollected = Mathf.Clamp(player.totalYellowCoinsCollected + moneyAmount, 0, 100);
        globalManager.NewCoinCollected();
    }

    #endregion
}
