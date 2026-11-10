using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Este objeto debe tener X puntos de vida
/// * Este objeto debe inventarse una lista de 5 puntos para hacer una ruta cíclica
/// * Este objeto debe desaparecer cuando su vida llega a 0 solamente
/// </summary>
public class B_EvilBalloon : MonoBehaviour
{
    #region ATTRIBUTES
    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 2)]
    float switchDistance = 0.5f;

    [SerializeField]
    [Range(1, 55)]
    float speed = 2;

    // Referencia al manager de globos
    M_Balloons myManager; 

    // Variable de puntos de vida
    [SerializeField] int lifePoints = 10;

    // Lista de puntos para hacer su ruta/vigilancia cíclica
    List<Vector3> patrolList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    #endregion

    #region METHODS

    // Método de inicialización

    public void InitializeBalloon(M_Balloons manager, Vector3 newPos)
    {
        myManager = manager;
        transform.position = newPos;

        FillPatrolList();
    }
    
    void FillPatrolList()
    {
        for(int i=0; i<9; i++)
        {
            Vector3 newPoint = new Vector3(
                Random.Range(-20, 20f), 
                Random.Range(-15f, 15f), 
                Random.Range(-50f, 50f));
            patrolList.Add(newPoint);
        }
        //Serie de puntos para definir la ruta
        //repetir el proceso de manera secuencial
        //crear un nuevo Vector3 con valores aleatorios
        //añadir el vector3 a la lista
    }

    // Método de recorrer ruta
    void Update()
    {
        float currentDistance = Vector3.Distance
                (transform.position, currentDestinyPoint.position);

        if (currentDistance <= switchDistance)
        {
            // * Cambiar el valor del índice

            currentDestinyIndex = (currentDestinyIndex + 1) % patrolList.Count;
            // Primer caso: 0 = (0 + 1) % 2 -> 1 / 2 me da de resto 1
            // Segundo caso: 1 = (1 + 1) % 2 -> 2 / 2 me da de resto 0

            // * Asignar de nuevo el destino usando el nuevo índice
            currentDestinyPoint = patrolList[currentDestinyIndex];
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp
            (transform.position, currentDestinyPoint.position, Time.deltaTime * speed);

            transform.position = middlePoint;
        }
        //cogemos el siguiente punto de la lista y me aproximo
        //comparo si estoy lo bastante cerca
        //si lo estoy, paso al siguiente
        //si no lo estoy, me acerco al punto
    }
    // Método de finalizar ciclo de vida

    #endregion
}
