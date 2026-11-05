using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Detectar Input de usuario para saltar de una cámara a otra
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;

    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode fifthCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode sixthCameraKey = KeyCode.Alpha5;

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        // Cómo se comporta la lectura
        get { return _currentActiveCameraIndex; }

        // Cómo se comporta la escritura (cambios de la variable)
        set
        {
            // Modifico el valor de mi variable privada
            _currentActiveCameraIndex = value;

            // Utilizo el nuevo valor de forma automática
            SwitchToCinemachineCamera();
        }
    }

    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKeyDown(firstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }
        if (Input.GetKeyDown(secondCameraKey))
        {
            CurrentActiveCameraIndex = 1;
        }
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }
        if (Input.GetKeyDown(fourthCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(fifthCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }
        if (Input.GetKeyDown(sixthCameraKey))
        {
            CurrentActiveCameraIndex = 5;
        }
    }

    void SwitchToCinemachineCamera()
    {
        // Recorrer la lista entera de cinemachine cameras
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i == CurrentActiveCameraIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la priroridad a 1
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                // Para cada cámara, si NO es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }

    #endregion
}