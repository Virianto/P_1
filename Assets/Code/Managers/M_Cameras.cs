using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Quiero tener referencia a todas las cámaras virtuales (cinemachine) de la escena
/// Y detectar Input de usuario para saltar de una cámara a otra
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    int _currentActiveCameraIndex = 0;  // Es obligatorio q sea privado y tenga una barra baja
    public int CurrentActiveCameraIndex // Es obligatorio q sea público, que empiece con mayúscula y que se corresponda con la variable anterior
    {   // Como se comporta la lectura
        get { return _currentActiveCameraIndex; }
        // Como se comporta la escritura (Cambios de la variable)
        set
        { 
            // Modifico el valor de  mi variable privada
            _currentActiveCameraIndex = value; // value vale 0 ahora porque es lo que vale _currentActiveCameraIndex

            // Utilizo el nuevo valor de forma automática
            SwitchToCinemachineCamera();
        } 
    }

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;
    #endregion


    #region METHODS
    void Update()
    {
        // Y detectar Input de usuario para cambiar la cámara principal
        if (Input.GetKeyDown(firstCameraKey))
        {
            // Saltamos a cámara 0
            CurrentActiveCameraIndex = 0;
        }
        if (Input.GetKeyDown(secondCameraKey))
        {
            // Saltamos a cámara 1
            CurrentActiveCameraIndex = 1;
        }
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            // Saltamos a cámara 2
            CurrentActiveCameraIndex = 2;
        }
    }

    void SwitchToCinemachineCamera()
    {
        // Recorrer la lista entera de cinemachine cameras
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i == CurrentActiveCameraIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la prioridad a 1
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                // Para cada cámara si NO es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }

    #endregion
}
