using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_FlyingEnemy : MonoBehaviour
{
    #region ATTRIBUTES

    M_FlyingEnemies myManager;

    B_PlayerPlane player;

    public float minLifeTime = 20;
    public float maxLifeTime = 30;

    public float maxLifePoints = 10;

    public float currentLifePoints;

    [SerializeField]
    [Range(1, 50)]
    public float speed = 5;

    [SerializeField]
    [Range(20, 200)]
    float horizontalXRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float verticalYRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float horizontalZRange = 100;

    [SerializeField]
    List<Vector3> patrolPointsList = new();

    [SerializeField]
    [Range(0, 2.5f)]
    float switchDistance = 1;

    int currentDestinyIndex = 0;

    #endregion





    #region METHODS

    private void Awake()
    {
        currentLifePoints = maxLifePoints;
    }

    private void Update()
    {
        // Saber si está lo bastante cerca del punto de destino o no
        float currentDistance = Vector3.Distance(transform.position, patrolPointsList[currentDestinyIndex]);

        if (currentDistance <= switchDistance)
        {
            // Cambiar el valor del índice
            // Primero: 0 = (0 + 1) % 2 -> 1 / 2. Resto 1
            // Segundo: 1 = (1 + 1) % 2 -> 2 / 2. Resto 0
            currentDestinyIndex = (currentDestinyIndex + 1) % patrolPointsList.Count;
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp(transform.position, patrolPointsList[currentDestinyIndex], speed * Time.deltaTime);
            transform.position = middlePoint;
        }
    }

    void FillPatrolPointsList()
    {
        for (int i = 0; i < 9; ++i)
        {
            Vector3 newPoint = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(-verticalYRange, verticalYRange), Random.Range(-horizontalZRange, horizontalZRange));

            patrolPointsList.Add(newPoint);
        }
    }

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeFlyingEnemy(M_FlyingEnemies manager, Vector3 newPosition)
    {
        // Referencia al Manager
        myManager = manager;

        // Referencia a la posición de creación
        transform.position = newPosition;

        // Definimos una serie de puntos por los que se va a mover el enemigo
        FillPatrolPointsList();

        StartCoroutine(FinishLifeCycle());
    }

    public void ModifyFlyingEnemyLifePoints(int amount)
    {
        currentLifePoints += amount;

        if (currentLifePoints <= 0)
        {
            myManager.FinishFlyingEnemyLifeCycle(this);
        }
    }

    /// <summary>
    /// Gestionar el ciclo de vida de las monedas
    /// </summary>
    IEnumerator FinishLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en Initialize (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en Initialize (donde hemos metido la corutina)

        myManager.FinishFlyingEnemyLifeCycle(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<B_PlayerPlane>();

        if (player != null)
        {
                player.ModifyLife(-10);
                M_FlightCameras.Instance.ChangeCamera(1);
        }
        myManager.FinishFlyingEnemyLifeCycle(this);
    }

    #endregion
}