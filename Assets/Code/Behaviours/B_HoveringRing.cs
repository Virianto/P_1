using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_HoveringRing : MonoBehaviour
{

    #region ATTRIBUTES

    public enum RingsType
    {
        Points,
        Life,
        Speed,
        Time
    }

    M_Rings myManager;

    RingsType ringsType;

    [SerializeField]
    List<Color> ringsTypeColorsList = new();

    #endregion



    #region METHODS

    public void InitializeRing(M_Rings manager, RingsType newRingType)
    {
        myManager = manager;
        ringsType = newRingType;

        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        for (int r = 0; r < allRingRenderers.Length; ++r)
        {
            allRingRenderers[r].material.color = ringsTypeColorsList[(int)ringsType];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (ringsType == RingsType.Points)
        {
            M_FlightSimulator.Instance.SetNewPoints(5);
        }

        if (ringsType == RingsType.Life)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            if (player != null)
            {
                player.ModifyPlayerLife(-5);
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de sacudida
            }
        }

        if (ringsType == RingsType.Speed)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            if (player != null)
            {
                // Modifico la velocidad del jugador
                player.SetNewSpeed(3);
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad

            }
        }

        if (ringsType == RingsType.Time)
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
            M_FlightSimulator.Instance.ModifyGameTimeLeft(5);
        }

    }




    #endregion
}