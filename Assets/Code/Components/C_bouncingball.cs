using UnityEngine;


/// <summary>
/// conservar una referencia del manager que le creó
/// modificar sus propios atributos al nacer
/// comunicar a su manager cuando debe desaparacer
/// </summary>
/// <param name="manager"> referencia al manager que creó sta instancia</param>

public class C_bouncingball : MonoBehaviour
{
    #region ATTRIBUTES

    M_ballspawn myManager;

    #endregion

    #region METHODS

    public void InitializeBall(M_ballspawn manager, Vector3 newPosition)
    {
        //aplicar las modificacicones y guardar referencias que me llegan por parametros
        myManager = manager;
        transform.position = newPosition;

    }

    #endregion
}

