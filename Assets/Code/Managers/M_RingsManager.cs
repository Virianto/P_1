using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// * Crear una instancia nueva del prefab del anillo cada cierto tiempo
/// * Decidir qué tipo de anillo será
/// * Gestionar el ciclo de vida del anillo
/// </summary>
public class M_RingsManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject ringPrefab;

    List<B_HoveringRing> allInstantiatedRingsList = new();

    public float minCreationFrequency = 5;
    public float maxCreationFrequency = 10;

    [SerializeField]
    [Range(20, 200)]
    float horizontalXRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float verticalYRange = 100;

    [SerializeField]
    [Range(20, 200)]
    float horizontalZRange = 100;

    #endregion





    #region METHODS

    /// <summary>
    /// Comenzar la corutina al empezar el juego
    /// </summary>
    private void Start()
    {
        StartCoroutine(CreateRing());
    }

    /// <summary>
    /// Generar anillos de manera continuada en el tiempo
    /// </summary>
    IEnumerator CreateRing()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(-verticalYRange, verticalYRange), Random.Range(-horizontalZRange, horizontalZRange));

        GenerateNewRingPrefab(newRandomPosition);

        yield return new WaitForSeconds(Random.Range(minCreationFrequency, maxCreationFrequency));

        StartCoroutine(CreateRing());
    }

    /// <summary>
    /// Crea un anillo nuevo, lo registra en la lista y lo inicializa
    /// </summary>
    /// <param name="newPosition"> Ubicación de origen para el nuevo anillo </param>
    void GenerateNewRingPrefab(Vector3 newPosition)
    {
        // Generar una instancia del prefab
        B_HoveringRing newRing = Instantiate(ringPrefab).GetComponent<B_HoveringRing>();

        // Decidir al azar de qué tipo va a ser el anillo
        // RingType newRingType = (RingType)Random.Range(0, 4);

        // Añadir el anillo a la lista de objetos generados
        allInstantiatedRingsList.Add(newRing);
        newRing.InitializeRing(this, newPosition);
    }

    /// <summary>
    /// Ejecuta las funciones necesarias para "finiquitar" un anillo
    /// </summary>
    /// <param name="endRing"> Anillo que ha solicitado su fin </param>
    public void FinishRingLifeCycle(B_HoveringRing endRing)
    {
        // Eliminamos el anillo de la lista
        allInstantiatedRingsList.Remove(endRing);

        // Destruimos el objeto
        Destroy(endRing.gameObject);
    }

    #endregion
}