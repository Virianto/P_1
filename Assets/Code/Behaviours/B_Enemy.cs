using UnityEngine;

/// <summary>
/// Va a tener una vida
/// Va a entrar dentro de una lista de enemigos
/// Va a seguir una ruta
/// 
/// </summary>
public class B_Enemy : MonoBehaviour
{

    #region ATTRIBUTES

    M_EnemiesManager myManager;

    #endregion


    #region METHODS

    public void InitializeEnemy(M_EnemiesManager manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;

    }

    #endregion
}
