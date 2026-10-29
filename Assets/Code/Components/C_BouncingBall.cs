using UnityEngine;

/// <summary>
/// * Va a conservar una referencia al Manager q la creó
/// * Va a modificar sus propios atributos al nacer
/// * Va a comunicar a su manager cuando debe desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES
    M_BallsSpawn nyManager;

    #endregion


    #region METHODS
    /// <summary>
    /// Aplica modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición al manager q creó esta instáncia</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition)
    {
        // Aplicar modificaciones y guardar referencia que me llegan por parámetros
        nyManager = manager;
        transform.position = newPosition;
    }

    #endregion
}
