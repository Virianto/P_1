using UnityEngine;

/// <summary>
/// * Instanciar un prefab de anillo en algún punto aleatorio de la escena
/// * Indicar a ese anillo de qué tipo es para que se inicialice
/// * Gestionar el ciclo de vida del anillo
/// * ¿¿??
/// </summary>
public class M_Rings : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    GameObject ringPrefab;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 30)]
    float horizontalRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float depthRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float verticalRandomLimit = 10;

    #endregion

    #region METHODS

    void GenerateNewRandomRing()
    {
        // Decisión "al azar" de qué tipo asignar a mi futuro nuevo anillo:
        RingModificationType newRingType = (RingModificationType)Random.Range(0, 4);        

        // Aquí hay que hacer muuuuuchas cosas. Buena suerte
    }

    #endregion
}
