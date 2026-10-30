using UnityEngine;
using System.Collections;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class C_SuperMonedas : MonoBehaviour
{
    #region ATTRIBUTES

    M_ManagerMonedas myManager;

    float lifeTime = 1;
    #endregion



    #region METHODS 
    /// <summary>
    /// Aplica modificaciones y guarda referencias
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición en la que ubicar el objeto</param>   

    public void InitializeBall(M_ManagerMonedas manager, Vector3 newPosition, float lifeTime)
    {
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "SuperMoneda " + Random.value.ToString();

        this.lifeTime = lifeTime;
        StartCoroutine(FinishLifeCycle());
    }

    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);

        myManager.FinishSuperMonedaLifeCycle(this);
    }


    #endregion
}
