using UnityEngine;
using System.Collections;

/// <summary>
/// * Va a conservar una referencia al Manager q la creó
/// * Va a modificar sus propios atributos al nacer
/// * Va a comunicar a su manager cuando debe desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES
    M_BallsSpawn myManager;

    float lifeTime = 1;
    #endregion


    #region METHODS
    /// <summary>
    /// Aplica modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición al manager q creó esta instáncia</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition, float lifeTime)
    {
        // Aplicar modificaciones y guardar referencia que me llegan por parámetros
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Bola" + Random.value.ToString();
        GetComponent<Rigidbody>().AddExplosionForce(500, Vector3.zero, 150);

        this.lifeTime = lifeTime;

        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        // Si escribo código aquí, SÍ que es relevante el orden en Initialize

        yield return new WaitForSeconds(lifeTime);

        // Si escribo código aquí, NO es relevante le orden en Initializa

        // Aviso al manager de que ha terminado mi tiempo
        // * Necesitaré un método público en el manager q haga algo
        myManager.FinishBallLifeCycle(this);
    }

    #endregion
}
