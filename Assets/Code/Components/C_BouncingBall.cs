using UnityEngine;
using System.Collections;

/// <summary>
/// * va a conservar una referencia al manager que la creo
/// * va a modificar sus propios atributos al nacer
/// * va a cominicar a su manager cuando desaparecer
/// </summary>
public class C_BouncingBall : MonoBehaviour
{
    #region ATTRIBUTES
    M_BallsSpawn myManager;
    float lifeTime=1;
    #endregion

    #region METHODS
    /// <summary>
    /// aplicar modificaciones y guardar referencia al manager
    /// </summary>
    /// <param name="manager">Referencia al manager que creo esta instancia</param>
    /// <param name="newPosition">Posicion donde se va a ubicar la instancia</param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition, float lifeTime)
    {
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Bola " + Random.value.ToString();
        GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 150);

        this.lifeTime=lifeTime;
        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        //si escribo código aquí, SÍ Q ES RELEVANTE el orden de Initialize
        yield return new WaitForSeconds(lifeTime);

        // Aviso al manager de q ha terminado mi tiempo
        // * Necesitaré un método public q 

        myManager.FinishBallLifeCycle(this);
    }
    #endregion
}
