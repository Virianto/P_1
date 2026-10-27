using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tiene dos puntos en escena y se mueven de forma cíclica
/// </summary>
public class B_Dynamic : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")] //Comentario en EditorUnity
    [SerializeField]
    [Range(0.1f, 2f)]
    float switchDistance = 0.5f;

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
        currentDestinyPoint = routePointsList[currentDestinyIndex];
    }

    /// <summary>
    /// Desplazar de forma suavizada el objeto hacia el primer punto de la lista
    /// </summary>
    private void Update()
    {
        //Necesito saber si estoy lo bastante cerca o no de mi destino

        float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);
        if (currentDistance <= switchDistance)
        {
            //Si estoy cerca...
            //Cambio de punto de destino
            //* Cambiar el valor del indice
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointsList.Count;

            //Primer caso: 0 = (0+1) % 2 -> 1/2 da resto 1
            //Segundo caso: 1 = (1+1) % 2 -> 2/2 da resto 0

            //* Asignar de nuevo el destino usando el nuevo indice
            currentDestinyPoint = routePointsList[currentDestinyIndex];
        }
        else
        {
            //Si estoy lejos...
            //Me sigo acercando
            Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position,
            Time.deltaTime * speed);

            transform.position = middlePoint;
        }

        //* Velocidad a la que me aproximo al destino
    }

    #endregion
}
