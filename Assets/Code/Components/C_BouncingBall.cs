using UnityEngine;

public class C_BouncingBall : MonoBehaviour
{
    M_BallsSpawn myManager;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    public void InitializeBall(M_BallsSpawn manager)
    {
        myManager = manager;
    }

}
