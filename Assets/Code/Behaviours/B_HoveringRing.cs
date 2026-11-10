
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>

public enum RingsType
    {
        Points,
        Life,
        Speed,
        Time
    }

public class B_HoveringRing : MonoBehaviour
{

    #region ATTRIBUTES



    M_Rings myManager;

    RingsType ringsType;

    [SerializeField]
    List<Color> ringsTypeColorsList = new();

    bool ringIsActive = true;

    #endregion



    #region METHODS

    public void InitializeRing(M_Rings manager, RingsType newRingType, Vector3 newRingPos, float lifeTime)
    {
        myManager = manager;
        ringsType = newRingType;
        transform.position = newRingPos;

        ChangeRingColor();

        StartCoroutine(FinishThisRingLifeCycle(lifeTime));

        //for (int r = 0; r < allRingRenderers.Length; ++r)
        //{
        //    allRingRenderers[r].material.color = ringsTypeColorsList[(int)ringsType];
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponent<B_PlayerPlane>();

        if (ringsType == RingsType.Points)
        {
            // Busco al manager de juego y le sumo los puntos
            M_FlightSimulator.Instance.SetNewPoints(5);
        }

        else if (ringsType == RingsType.Life)
        {
            
            if (player != null)
            {
                player.ModifyPlayerLife(-5);
                //M_Cameras.Instance.CurrentActiveCameraIndex = 1;
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de sacudida
            }
        }

        else if (ringsType == RingsType.Speed)
        {
            
            if (player != null)
            {
                // Modifico la velocidad del jugador
                player.speed += 3;
                // Busco al manager de cámaras y le hago un cambio temporal a la cámara de velocidad

            }
        }

        else if (ringsType == RingsType.Time)
        {
            // Busco la instancia del manager y le aumento X segundos de tiempo
            M_FlightSimulator.Instance.ModifyGameTimeLeft(5);
        }

        // Si el jugador ha pasado por aquí:
        if(player != null)
        {
            // Este anillo ya no sirve y se cancela la rutina
            ringIsActive = false;
            // Le indico al gesto que acabe conmigo
            myManager.FinishRingLifeCycle(this);
        }

    }

    IEnumerator FinishThisRingLifeCycle(float timeLeft)
    {
        yield return new WaitForSeconds(timeLeft);

        if (ringIsActive)
        {
                myManager.FinishRingLifeCycle(this);
        }
    }

    public void ChangeRingColor()
    {
        // PASO 1 - BUSCAR Y ALMACENAR TODOS LOS RENDERER DE ESTE OBJETO
        // - Crear una variable donde guardar las refrencias
        // - Buscar todas esas refrencias en la jerarquía
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        // PASO 2 - RECORER LA VARIABLE CON LAS REFERENCIAS
        for(int i = 0; i < allRingRenderers.Length; i++)
        {
            // PASO 3 - CAMBIAR COLOR DE CADA ELEMENTO SEGÚN EL TIPO
            // - Acceder al elemento de la posición "i"
            // - Buscar el material y su color
            // - Convertir el color según el tipo de anillo (con un parseo)
            allRingRenderers[i].material.color = ringsTypeColorsList[(int)ringsType];

        }

    }


    #endregion
}