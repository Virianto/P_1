using UnityEngine;

/// <summary>
/// Esta clase debe hacer todo lo que se ha indicado en el enunciado del ejercicio
/// (Ese precioso, maravilloso y glorioso PAINT)
/// </summary>
public class M_Rings : MonoBehaviour
{
    #region ATTRIBUTES


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
