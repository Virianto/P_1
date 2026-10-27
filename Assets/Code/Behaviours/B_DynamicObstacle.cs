using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Un obstáculo que va a tener dos puntos de referencia en escena y se va a mover entre ellos de forma cíclica
/// </summary>
public class B_DynamicObstacle : MonoBehaviour
{
    #region ATTRIBUTES
    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]

    [SerializeField]
    [Range(0, 2.5f)] float switchDistance = 1;

    [Range(0, 10)] public float speed = 0;

    [SerializeField]
    List<Transform> routePointsList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;
   
    #endregion





    #region METHODS

    private void Awake()
    {
        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }

    private void Update()
    {
        // Saber si está lo bastante cerca del punto de destino o no
        float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);
        if(currentDistance <= switchDistance)
        {
            // Cambiar el valor del índice
            // Primero: 0 = (0 + 1) % 2 -> 1 / 2. Resto 1
            // Segundo: 1 = (1 + 1) % 2 -> 2 / 2. Resto 0
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;

            // Asignar de nuevo el destino usando el nuevo índice
            currentDestinyPoint = routePointsList[currentDestinyIndex];
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, speed * Time.deltaTime);
            transform.position = middlePoint;
        }
        
    }

    #endregion
}