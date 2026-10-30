using UnityEngine;

/// <summary>
/// * va a conservar una referencia al manager que la creo
/// * va a modificar sus propios atributos al nacer
/// * va a cominicar a su manager cuando desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES
    M_BallsSpawn myManager;
    #endregion

    #region METHODS
    /// <summary>
    /// aplicar modificaciones y guardar referencia al manager
    /// </summary>
    /// <param name="manager">Referencia al manager que creo esta instancia</param>
    /// <param name="newPosition">Posicion donde se va a ubicar la instancia</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;
    }
    #endregion
}
