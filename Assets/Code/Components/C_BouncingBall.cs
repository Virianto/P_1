using UnityEngine;

/// <summary>
/// * Va a conservar una referencia al manager que la creó
/// * Va a modificar sus propios atributos al nacer
/// * Va a comunicar a su manager cuándo debe desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{

    #region ATTRIBUTES

    M_BallsSpawner myManager;

    #endregion



    #region METHODS

    /// <summary>
    /// Aplicar modificaciones y guardar referencias que me llegan por parámetros
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición en la que ubicar el objeto</param>
    public void InitializeBall(M_BallsSpawner manager, Vector3 newPosition)
    {
        // 
        myManager = manager;
        transform.position = newPosition;

    }

    #endregion
}