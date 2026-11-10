using System.Collections;
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

    bool ringIsActive = true;

    #endregion

    #region METHODS

    /// <summary>
    /// Añadir todos los parámetros del enunciado en esta declaración
    /// </summary>
    public void InitializeRing(M_Rings manager, RingModificationType newRingType, Vector3 newRingPos, float lifeTime)
    {        
        myManager = manager;
        ringType = newRingType; 
        transform.position = newRingPos;

        StartCoroutine(FinishThisRingLifeCycle(lifeTime));

        //Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        //for(int r = 0; r < allRingRenderers.Length; ++r)
        //{
        //    allRingRenderers[r].material.color = ringTypeColorsList[(int)ringType];
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();

        if (ringType == RingModificationType.Points)
        {
            // Busco al manager del juego y le sumo los puntos          
        }
        else if(ringType == RingModificationType.Life)
        {            
            if (player != null) 
            {
                player.ModifyPlayerLife(-5);
                //M_Cameras.Instance.ChangeCamera(índice de la cámara);
            }
        }
        else if( ringType == RingModificationType.Speed)
        {            
            if (player != null)
            {
                player.speed += 3;
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad
            }            
        }
        else if (ringType == RingModificationType.Time) 
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
            M_FlightSimulator.Instance.ModifyGameTimeLeft(5);            
        }

        // Si el jugador ha pasado por aquí:
        if(player != null)
        {
            // Este anillo ya no sirve y se cancela la rutina
            ringIsActive = false;

            // Le indico al gestor que acabe conmigo
            myManager.FinishRingLifeCycle(this);
        }
    }

    IEnumerator FinishThisRingLifeCycle(float timeLeft)
    {
        yield return new WaitForSeconds(timeLeft);
        
        // Solamente elimino el anillo si aún no ha sido activado por el jugador
        if (ringIsActive)
        {
            myManager.FinishRingLifeCycle(this);
        }
    }

    #endregion
}
