using UnityEngine;

/// <summary>
/// * Va a conservar una referencia al manager que la creó
/// * Va a amodificar sus propios atributos al nacer
/// * Va a comunicar a su manager cuándo debe desaparecer
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
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición en la que ubicar el objeto</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Bola " + Random.value.ToString();
        GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 250);
    }

    #endregion
}
