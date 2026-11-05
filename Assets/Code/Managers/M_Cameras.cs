using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


/// <summary>
/// * Tener referencias a todas las cámaras virtuales (cinemachine cameras) de la escena
/// * Detectar Input de usuario para saltar de una cámara a otra
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES

    // Tener referencias a todas las cámaras virtuales (cinemachine cameras) de la escena

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode thirdCameraKey = KeyCode.Alpha2;

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
        get
        {
            return _currentActiveCameraIndex;
        }

        // Cómo se comporta la escritura
        set
        {
            // Modificamos el valor de la variable privada
            _currentActiveCameraIndex = value;

            // Utilizamos el nuevo valor de forma automática
            SwitchToCinemachineCamera();
        }
    }

    #endregion





    #region METHODS

    private void Update()
    {
        // Detectar Input de usuario para saltar de una cámara a otra
        if (Input.GetKeyDown(firstCameraKey))
        {
            // Cámara 0
            // SwitchToCinemachineCamera(0);
            CurrentActiveCameraIndex = 0;
        }

        if (Input.GetKeyDown(secondCameraKey))
        {
            // Cámara 1
            // SwitchToCinemachineCamera(1);
            CurrentActiveCameraIndex = 1;
        }

        if (Input.GetKeyDown(thirdCameraKey))
        {
            // Cámara 2
            // SwitchToCinemachineCamera(2);
            CurrentActiveCameraIndex = 2;
        }

        if (Input.GetKeyDown(fourthCameraKey))
        {
            // Cámara 3
            // SwitchToCinemachineCamera(3);
            CurrentActiveCameraIndex = 3;
        }

        if (Input.GetKeyDown(fifthCameraKey))
        {
            // Cámara 4
            // SwitchToCinemachineCamera(4);
            CurrentActiveCameraIndex = 4;
        }

        if (Input.GetKeyDown(sixthCameraKey))
        {
            // Cámara 5
            // SwitchToCinemachineCamera(5);
            CurrentActiveCameraIndex = 5;
        }
    }

    void SwitchToCinemachineCamera()
    {
        // Recorrer la lista de cinemachine cameras
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            // Para cada cámara, si es la que queremos, le cambiamos la prioridad a 1
            if (i == CurrentActiveCameraIndex)
            {
                allVirtualCamerasList[i].Priority = 1;
            }
            // Para cada cámara, si no es la que queremos, le cambiamos la prioridad a 0
            else
            {
                allVirtualCamerasList[i].Priority = 0;
            }
        }

    }

    #endregion
}