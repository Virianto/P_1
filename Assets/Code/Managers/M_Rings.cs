using System;
using UnityEngine;
using Random = UnityEngine.Random;
using static B_HoveringRing;

/// <summary>
/// * Instanciar nuevo anillo cada X segundos (editables)
/// </summary>
public class M_Rings : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    Transform spawnOrigin;
    [SerializeField]
    GameObject ringPrefab;

    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float xRotation = 5;

    [SerializeField]
    [Range(1, 15)]
    float yRotation = 5;

    M_Rings myManager;

    RingsType ringsType;

    #endregion



    #region METHODS

    void GenerateNewRandomRing()
    {
        // Detectar una tecla para generar una esfera en el spawnOrigin
        RingsType newRingType = (RingsType)Random.Range( 0, 4);


    }

    void InitializeRing()
    {


    }

    #endregion
}