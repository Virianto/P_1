using System.Collections.Generic;
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

    [SerializeField]
    List<Color> ringTypeColorsList = new();

    #endregion

    #region METHODS

    /// <summary>
    /// Añadir todos los parámetros del enunciado en esta declaración
    /// </summary>
    public void InitializeRing(M_Rings manager, RingModificationType newRingType, Vector3 newRingPos)
    {        
        myManager = manager;
        ringType = newRingType; 
        transform.position = newRingPos;

        //Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        //for(int r = 0; r < allRingRenderers.Length; ++r)
        //{
        //    allRingRenderers[r].material.color = ringTypeColorsList[(int)ringType];
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (ringType == RingModificationType.Points)
        {
          
        }

        if(ringType == RingModificationType.Life)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            if (player != null) 
            {
                player.ModifyPlayerLife(-5);
                //M_Cameras.Instance.ChangeCamera(índice de la cámara);
            }
        }

        if( ringType == RingModificationType.Speed)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            if (player != null)
            {
                // Modifico la velocidad del jugador
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad
            }            
        }

        if (ringType == RingModificationType.Time) 
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
            M_FlightSimulator.Instance.ModifyGameTimeLeft(5);            
        }

    }

    #endregion
}
