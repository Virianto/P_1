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

        ChangeRingColor();

        StartCoroutine(FinishThisRingLifeCycle(lifeTime));        
    }

    void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();

        if (ringType == RingModificationType.Points)
        {
            //M_FlightSimulator.Instance.SumarPuntos();
        }
        else if(ringType == RingModificationType.Life)
        {            
            if (player != null) 
            {
                player.ModifyPlayerLife(-5);
                M_Cameras.Instance.CurrentActiveCameraIndex = 2;
            }
        }
        else if( ringType == RingModificationType.Speed)
        {            
            if (player != null)
            {
                player.speed += 3;
                M_Cameras.Instance.CurrentActiveCameraIndex = 3;
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

    void ChangeRingColor()
    {
        // PASO 1 - BUSCAR Y ALMACENAR TODOS LOS RENDERER DE ESTE OBJETO
        // - Crear una variable donde guardar las referencias
        // - Buscar todas esas referencias en la jerarquía
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        // PASO 2 - RECORRER LA VARIABLE CON LAS REFERENCIAS
        for(int i = 0;  i < allRingRenderers.Length; ++i)
        {
            //  PASO 3 - CAMBIAR COLOR DE CADA ELEMENTO SEGÚN EL TIPO
            // - Acceder al elemento de la posición 'i'
            // - Buscar el material y su color
            // - Convertir el color según el tipo de anillo (con un parseo)
            allRingRenderers[i].material.color = ringTypeColorsList[(int)ringType];
        }
    }

    #endregion
}
