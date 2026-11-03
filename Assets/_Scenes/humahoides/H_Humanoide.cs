using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class H_Humanoide : MonoBehaviour
{
    #region ATTRIBUTES

    M_managerHumanoide myManager;

    float lifeTime = 1;

    #endregion


    #region METHODS 
    /// <summary>
    /// Aplica modificaciones y guarda referencias
    /// </summary>
    /// <param name="manager">Referencia al manager que creó esta instancia</param>
    /// <param name="newPosition">Nueva posición en la que ubicar el objeto</param>   

    public void InitializeHumanoide(M_managerHumanoide manager, Vector3 newPosition, float lifeTime)

    {
        myManager = manager;
        transform.position = newPosition;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObject.name = "Humanoide " + Random.value.ToString();

    }
    #endregion
}
