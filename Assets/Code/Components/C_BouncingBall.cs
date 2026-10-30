using System.Collections;
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

    float lifeTime = 1;

    #endregion





    #region METHODS
    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeBall(M_BallsSpawn manager, Vector3 newPosition, float lifeTime)
    {
        MyManager = manager;
        transform.position = newPosition;
        this.lifeTime = lifeTime;

        // Modificar el color aleatoriamente
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        // Modificar el nombre aleatoriamente
        name = "Bola " + Random.value.ToString();

        // Modificar la fuerza del movimiento inicial
        GetComponent<Rigidbody>().AddExplosionForce(300, Vector3.zero, 150);

        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(lifeTime);

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishBallLifeCycle(this);
    }

    #endregion
}