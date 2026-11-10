using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_Ring : MonoBehaviour
{
    #region ATTRIBUTES

    M_SpawnAnillos myManager;

    RingType type;

    #endregion
    #region METHODS

    public void InitializeRing(M_SpawnAnillos manager, Vector3 newPosition, RingType tipo, Color color)
    {
        myManager = manager;
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < allRingRenderers.Length; i++)
        {
            allRingRenderers[i].material.color = color;
        }
        transform.position = newPosition;
        type = tipo;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("E entrado en un portal");
        if (type == RingType.Points)
        {
            M_ManagerCanvasAvion.Instance.CurrentsPoints(1);
        }

        if (type == RingType.Life)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            M_Cameras camera = other.GetComponent<M_Cameras>();
            if (player != null)
            {
                Debug.Log("Me e echo daño");
                player.ModifyPlayerLife(-1);
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de sacudida
                camera.EnterRingDamage(1);
            }
        }

        if (type == RingType.Speed)
        {
            B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();
            M_Cameras camera = other.GetComponent<M_Cameras>();
            if (player != null)
            {
                player.CurrentSpeed(Random.Range(20,100));
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad
                camera.EnterRingSpeed(2);
            }
        }

        if (type == RingType.Time)
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
            M_ManagerCanvasAvion.Instance.PlayerTimeChanged(Random.Range(1,10));
        }

    }

    #endregion
}