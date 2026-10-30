using System.Collections;
using UnityEngine;

/// <summary>
/// * Va a conservar una referencia al manager que la creó
/// * Va a modificar sus propios atributos al nacer
/// * Va a comunicar a su manager cuándo debe desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES

    M_BallsSpawn myManager;

    float lifeTime = 1;
    #endregion

    #region METHODS

    /// <summary>
    /// Aplica modificaciones y guarda referencias
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición en la que ubicar el objeto</param>   
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition, float lifeTime)
    {        
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Bola " + Random.value.ToString();
        GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 150);

        this.lifeTime = lifeTime;
        StartCoroutine(FinishLifeycle());
    }

    IEnumerator FinishLifeycle()
    { 
        yield return new WaitForSeconds(lifeTime);

        myManager.FinishBallLifeCycle(this);
    }

    #endregion
}
