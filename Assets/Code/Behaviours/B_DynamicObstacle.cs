using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Tiene dos puntos en escena y se mueve entre ellos de forma cíclica
/// </summary>
public class B_DynamicObstacle : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 1.5f)]
    float switchDistance = 0.5f;

    [SerializeField]
    [Range(1, 10)]
    float speed = 2;

    [SerializeField]
    List<Transform> routePointsList = new();

    Transform currentDestinyPoint;

    #endregion

    #region METHODS

    void Update()
    {
        // Desplazar de forma suavizada el objeto hacia el primer punto de la lista
        // * Punto actual de destino
        // * Velocidad a la que me aproximo a ese destino
    }

    #endregion
}
