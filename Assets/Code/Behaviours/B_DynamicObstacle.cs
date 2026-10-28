using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tiene dos puntos en escena y se va a mover entre ellos de forma cíclica
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
    float speed = 1;


    [SerializeField]
    List<Transform> routePointsList = new();

    public bool shouldMove = false;

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    #endregion



    #region METHODS

    void Awake()
    {
        currentDestinyPoint = routePointsList[0];
    }
    void Update()
    {

        if (shouldMove)
        {

            // Necesito saber si estoy lo bastante cerca o no de mi punto de destino
            float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);
            // Si ya estoy cerca

            if(currentDistance <= switchDistance)
            {
                // Cambio de punto de destino
                // * Cambiar el valor del índice

                currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;

                // Primer caso: 0 = (0 + 1) % 2 -> 1 / 2 me da de resto 1
                // Segundo caso: 1 = (1 + 1) % 2 -> 2 / 2 me da de resto 0

                // * Asignar de nuevo el destino usando el nuevo índice
                currentDestinyPoint = routePointsList[currentDestinyIndex];
            }
            else
            {
                // Si estoy lejos
                // Me sigo acercando
                // Desplazar de forma suavizada el objeto hacia el primer punto de la lista
                Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, Time.deltaTime * speed);

                transform.position = middlePoint;

            }

        }
        



        // * Punto actual de destino
        // * Velocidad a la que me aproximo a ese destino

        
    }

    #endregion
}