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

    // Referencia al manager
    M_Balloons myManager;

    // Variable de puntos de vida
    [SerializeField]
    int lifePoints = 10;

    // Lista de puntos para hacer su ruta/vigilancia cíclica
    List<Vector3> patrolPointsList = new();

    int currentDestinyIndex = 0;

    #endregion

    #region METHODS

    // Método de inicialización
    public void InitializeBalloon(M_Balloons manager, Vector3 newPos)
    {
        myManager = manager;
        transform.position = newPos;

        FillPatrolPointsList();        
    }

    void FillPatrolPointsList()
    {
        for(int i = 0; i < 9; ++i)
        {
            // Nos inventamos una serie de puntos para definir nuestra nueva ruta
            
            Vector3 newPoint = new Vector3(
                Random.Range(-20, 20),
                Random.Range(-15, 15),
                Random.Range(-50, 50));

            patrolPointsList.Add(newPoint);            
        }
    }

    // Método de recorrer ruta
    void Update()
    {
        // Necesito saber si estoy lo bastante cerca o no de mi punto de destino
        float currentDistance = Vector3.Distance
            (transform.position, patrolPointsList[currentDestinyIndex]);

        if (currentDistance < switchDistance) 
        {
            // * Cambiar el valor del índice
            currentDestinyIndex = (currentDestinyIndex + 1) % patrolPointsList.Count;
            // Primer caso: 0 = (0 + 1) % 2 -> 1 / 2 me da de resto 1
            // Segundo caso: 1 = (1 + 1) % 2 -> 2 / 2 me da de resto 0
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp
                (transform.position, patrolPointsList[currentDestinyIndex], Time.deltaTime * speed);

            transform.position = middlePoint;
        }
    }

    // Método de finalizar ciclo de vida

    #endregion
}
