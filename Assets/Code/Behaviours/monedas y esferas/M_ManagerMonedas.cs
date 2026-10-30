using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class M_ManagerMonedas : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalMonedasToCreate = 1;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]

    float horizontalZRange = 2;

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [SerializeField]
    KeyCode spawnRandomKey = KeyCode.H;

    [SerializeField]
    KeyCode spawnSequenceKey = KeyCode.J;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject MonedaPrefab;
    [SerializeField]
    GameObject SuperMonedaPrefab;
    [SerializeField]
    Transform spawnOrigin;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<C_Monedas> allInstantiatedMonedaList = new();
    #endregion
    List<C_SuperMonedas> allInstantiatedSuperMonedaList = new();


    #region METHODS 
    void Update()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        if (Input.GetKeyDown(spawnAtOriginKey))
        {
            GenerateNewPrefab(spawnOrigin.position);
        }
        // Detectar una tecla DIFERENTE para generar una oleada de esferas aleatorias
        if (Input.GetKeyDown(spawnRandomKey))
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefab(newRandomPosition);
        }
        // Detecta OTRA tecla para generar esferas de forma cíclica/secuencial
        if (Input.GetKeyDown(spawnSequenceKey))
        {
            GenerateSuperPrefab(spawnOrigin.position);
        }
    }

    /// <summary>
    /// Crea una esfera nueva, la registra en la lista y la inicializa
    /// </summary>
    /// <param name="newPosition">Ubicación de origen para la nueva esfera</param>

    void GenerateNewPrefab(Vector3 newPosition)
    {
        C_Monedas newMoneda = Instantiate(MonedaPrefab).GetComponent<C_Monedas>();

        allInstantiatedMonedaList.Add(newMoneda);
        newMoneda.InitializeBall(this, newPosition, Random.value * 5);
    }
    void GenerateSuperPrefab(Vector3 newPosition)
    {
        C_SuperMonedas newSuperMoneda = Instantiate(SuperMonedaPrefab).GetComponent<C_SuperMonedas>();

        allInstantiatedSuperMonedaList.Add(newSuperMoneda);
        newSuperMoneda.InitializeBall(this, newPosition, Random.value * 5);
    }
    public void FinishMonedaLifeCycle(C_Monedas Moneda)
    {
        allInstantiatedMonedaList.Remove(Moneda);

        Destroy(Moneda.gameObject);
    }
    public void FinishSuperMonedaLifeCycle(C_SuperMonedas superMoneda)
    {
        allInstantiatedSuperMonedaList.Remove(superMoneda);

        Destroy(superMoneda.gameObject);
    }
    #endregion
}
