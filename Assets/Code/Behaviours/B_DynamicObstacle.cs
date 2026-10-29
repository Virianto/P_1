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
    [Range(0.1f, 2)]
    float switchDistance = 0.5f;

    [SerializeField]
    [Range(1, 10)]
    float speed = 2;

    [SerializeField]
    List<Transform> routePointsList = new();

    public bool shouldMove = false;

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }

    void Update()
    {
        if (shouldMove)
        {
            // Necesito saber si estoy lo bastante cerca o no de mi punto de destino
            float currentDistance = Vector3.Distance
                (transform.position, currentDestinyPoint.position);

            if (currentDistance <= switchDistance)
            {
                // * Cambiar el valor del índice

                currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;
                // Primer caso: 0 = (0 + 1) % 2 -> 1 / 2 me da de resto 1
                // Segundo caso: 1 = (1 + 1) % 2 -> 2 / 2 me da de resto 0

                // * Asignar de nuevo el destino usando el nuevo índice
                currentDestinyPoint = routePointsList[currentDestinyIndex];
            }
            else
            {
                Vector3 middlePoint = Vector3.Lerp
                (transform.position, currentDestinyPoint.position, Time.deltaTime * speed);

                transform.position = middlePoint;
            }
        }                  
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Han chocado");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Han atravesado");
    }

    #endregion
}
