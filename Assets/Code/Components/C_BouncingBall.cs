using UnityEngine;

/// <summary>
/// * Va a conservar una referencia al manager que la creo
/// * Va a modificar sus propios atributos al nacer
/// * 
/// </summary>

public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES

    M_BallsSpawn myManager;

    #endregion
    #region METHODS


    /// <summary>
    /// Aplica modificaciones y guarda referencias
    /// </summary>
    /// <param name="manager"> Referencia al manager que creo esta instancia</param>
    /// <param name="newPosition"> Referencia a la nueva posicion asignada</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;
    }

   #endregion    
}

