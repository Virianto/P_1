
using System.Collections.Generic;
using UnityEngine;

public class B_DynamicObstacle : MonoBehaviour
{
    [Header("Configuración del movimiento")]

    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 2f)]
    private float switchDistance = 0.5f;

    [Tooltip("Velocidad de movimiento")]
    [SerializeField]
    private float speed = 2f;

    [Header("Puntos de ruta")]

    [SerializeField]
    private List<Transform> routePointsList = new List<Transform>();

    private Transform currentDestinyPoint;
    private int currentDestinyIndex = 0;

    #region METHODS

    void Awake()
    {
        // Comprobar que hay puntos de ruta asignados
        if (routePointsList == null || routePointsList.Count == 0)
        {
            Debug.LogWarning("No hay puntos de ruta asignados.", this);
            enabled = false;
            return;
        }

        // Comprobar que el primer punto no sea nulo
        if (routePointsList[0] == null)
        {
            Debug.LogWarning("El primer punto de ruta no está asignado.", this);
            enabled = false;
            return;
        }

        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }

    void Update()
    {
        if (currentDestinyPoint == null)
            return;

        // Calcular la distancia al destino actual
        float currentDistance = Vector3.Distance(
            transform.position,
            currentDestinyPoint.position
        );

        if (currentDistance <= switchDistance)
        {
            // Pasar al siguiente punto de la lista
            currentDestinyIndex =
                (currentDestinyIndex + 1) % routePointsList.Count;

            currentDestinyPoint = routePointsList[currentDestinyIndex];

            // Evitar errores si algún punto no está asignado
            if (currentDestinyPoint == null)
            {
                Debug.LogWarning("Hay un punto de ruta sin asignar.", this);
                enabled = false;
            }
        }
        else
        {
            // Mover suavemente el objeto hacia el destino
            Vector3 middlePoint = Vector3.Lerp(
                transform.position,
                currentDestinyPoint.position,
                Time.deltaTime * speed
            );

            transform.position = middlePoint;
        }
    }

    #endregion
}
