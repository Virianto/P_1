using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del prop�sito de esta clase
/// </summary>
public class B_Dynamic_Obstacle : MonoBehaviour
{
    #region ATTRIBUTES
    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 20)]
    float switchDistance = 2;

    [Tooltip("Velocidad a la que se mueve mi obstáculo")]
    [SerializeField] [Range(0.1f, 10)]
    float speed = 10;

    [SerializeField]
    List<Transform> routePointsList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    public bool shouldMove = false;

    #endregion


    #region METHODS
    void Awake()
    {
        // Desplazar de forma suavizada el objeto hacia el primer punto de la lista
        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }
    void Update()
    {
        if (shouldMove)
        {
            // Necesito sabe si estoy lo bastante cerca o no de mi destino
            float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);

            if (currentDistance <= switchDistance) // Si ya estoy cerca
            {
                // Cambio de destino
                currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;
                currentDestinyPoint = routePointsList[currentDestinyIndex];

            }
            else // Si estoy lejos
            {
                // Me sigo acercando
                Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, Time.deltaTime * speed);
                transform.position = middlePoint;
            }
        }
    }

    #endregion
}
