using UnityEngine;


/// <summary>
/// * Conservar una referencia al Manager que la creó
/// * Modificar sus propios atributos al nacer
/// * Comunicar al Manager cuándo debe desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES

    M_BallsSpawn MyManager;

    #endregion





    #region METHODS
    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition)
    {
        MyManager = manager;
        transform.position = newPosition;
    }

    #endregion
}