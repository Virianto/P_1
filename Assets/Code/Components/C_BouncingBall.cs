using System.Collections;
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

    float lifeTime = 1;

    #endregion
    #region METHODS


    /// <summary>
    /// Aplica modificaciones y guarda referencias
    /// </summary>
    /// <param name="manager"> Referencia al manager que creo esta instancia</param>
    /// <param name="newPosition"> Referencia a la nueva posicion asignada</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition, float lifeTime)
    {
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Bola " + Random.value.ToString();
        GetComponent<Rigidbody>().AddExplosionForce(100, Vector3.zero, 150);

        this.lifeTime = lifeTime;
        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        myManager.FinishBallLifeCycle(this);
    }

   #endregion    
}

