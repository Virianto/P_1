using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tiene dos puntos en escena y se mueve entre ellos de forma ciclica
/// </summary>

public class B_DinamicObstacle : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Distancia minima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 1.5f)]
    float swicthDistance = 0.5f;

    [SerializeField]
    [Range(1, 10)]
    float speed = 2;

    [SerializeField]
    List<Transform> routePointsList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    #endregion
    #region METHODS

    private void Awake()
    {
        currentDestinyPoint = routePointsList[0];
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);

        if (currentDistance < swicthDistance)
        {
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;
            currentDestinyPoint = routePointsList[currentDestinyIndex];
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, Time.deltaTime * speed);
            transform.position = middlePoint;
        }
    }

    #endregion
}

