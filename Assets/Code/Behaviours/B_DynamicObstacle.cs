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
        currentDestinyPoint = routePointsList[0];
        Vector3 middlePoint = Vector3.Lerp
            (transform.position, currentDestinyPoint.position, Time.deltaTime * speed);
        transform.position = middlePoint;
        if(currentDistance <= switchDistance)
        {
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;
            currentDestinyPoint = routePointsList[currentDestinyIndex];
        }
        else
        {
            Vector3middlePoint = Vector3.Lerp
                (transformn.position, currenDestinyPoint)
        }


    }

    #endregion
}
