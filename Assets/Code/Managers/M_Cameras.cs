using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Tener referencias a todas las cámaras virtuales (cinemachine) de la escena
/// * Detectar input de usuario para saltar de una cámara a otra
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
    KeyCode thirdCameraKey = KeyCode.Alpha2;
    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;
    [SerializeField]
    KeyCode fifthCameraKey = KeyCode.Alpha4;
    [SerializeField]
    KeyCode sixthCameraKey = KeyCode.Alpha5;
    [SerializeField]
    KeyCode seventhCameraKey = KeyCode.Alpha6;

    int _currentActiveCameraIndex = 0;
    public int CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }

        set 
        {
            //Modifico el valor de forma automática
            _currentActiveCameraIndex = value;
            //Utilizo el nuevo valor de forma automática
            switchToCinemachineCamera();
            Debug.Log($"camara {value}");
        }
    }

    #endregion

    #region METHODS

    private void Update()
    {
        //Detectar input para cambiar cámara principal
        if (Input.GetKeyDown(firstCameraKey))
            CurrentActiveCameraIndex = 0;
        //switchToCinemachineCamera(0);
        else if (Input.GetKeyDown(secondCameraKey))
            CurrentActiveCameraIndex = 1;
        //switchToCinemachineCamera(1);
        else if (Input.GetKeyDown(thirdCameraKey))
            CurrentActiveCameraIndex = 2;
        //switchToCinemachineCamera(2);
        else if (Input.GetKeyDown(fourthCameraKey))
            CurrentActiveCameraIndex = 3;
        else if (Input.GetKeyDown(fifthCameraKey))
            CurrentActiveCameraIndex = 4;
        else if (Input.GetKeyDown(sixthCameraKey))
            CurrentActiveCameraIndex = 5;
        else if (Input.GetKeyDown(seventhCameraKey))
            CurrentActiveCameraIndex = 6;
    }

    void switchToCinemachineCamera()
    {
        //Recorrer la lista de cinemachinecamera
        //Para cada cámara, si es el índice que quiero, le cambio la prioridad a 1
        //Para cada cámara, si no, le cambio prioridad a 5
        for (int i = 0; i < allVirtualCamerasList.Count; i++)
        {
            if (i == CurrentActiveCameraIndex)
                allVirtualCamerasList[i].Priority = 1;
            else
                allVirtualCamerasList[i].Priority = 0;
        }
    }

    #endregion
}
