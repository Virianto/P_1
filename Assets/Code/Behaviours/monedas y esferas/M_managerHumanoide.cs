using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class M_managerHumanoide : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalHumanoideToCreate = 1;

    [SerializeField]
    KeyCode spawnAtOriginKey = KeyCode.G;

    [Header("REFERENCIAS EXTERNAS")]

    [SerializeField]
    GameObject humanoidePrefab;

    [SerializeField]
    Transform spawnOrigin;

    #endregion


    #region METHODS 


    #endregion
    }
