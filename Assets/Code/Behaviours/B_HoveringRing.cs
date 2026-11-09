using UnityEngine;

public enum RingModificationType
{
    Points,
    Life,
    Speed,
    Time
}

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_HoveringRing : MonoBehaviour
{
    #region ATTRIBUTES

    M_Rings myManager;

    RingModificationType ringType;

    #endregion

    #region METHODS

    /// <summary>
    /// Añadir todos los parámetros del enunciado en esta declaración
    /// </summary>
    public void InitializeRing()
    {
        // Modificar las variables y referencias del anillo según los parámetros que reciba el método
        // myManager = ¿¿Parámetro??
        // ringType = ¿¿Parámetro??
        // ETC...
    }

    void OnTriggerEnter(Collider other)
    {
        if (ringType == RingModificationType.Points)
        {
            // Busco la instancia del manager y le aumento X puntos
        }

        if(ringType == RingModificationType.Life)
        {
            // Busco al jugador (a través de "other.GetComponent" por ejemplo) y le modifico la vida
            // Busco al manager de cámaras y le hago un cambio temporal a la cámara de sacudida
        }

        if( ringType == RingModificationType.Speed)
        {
            // Busco al jugador (a través de "other.GetComponent" por ejemplo) y le modifico la velocidad
            // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad
        }

        if (ringType == RingModificationType.Time) 
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
        }

    }

    #endregion
}
