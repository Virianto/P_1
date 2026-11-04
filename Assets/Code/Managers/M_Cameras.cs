
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Tener referencias a todas las cámaras virtuales o Cinemachine de las escena
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
    KeyCode thirdCameraKey = KeyCode.Alpha2;
    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;
    [SerializeField]
    KeyCode fifthCameraKey = KeyCode.Alpha4;

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

        // Detectar Input del usuario para cambiar la cámara principal

        if (Input.GetKeyDown(firstCameraKey))
        {

            // Saltamos a cámara 0
            // SwitchToCinemachineCamera(0);
            CurrentActiveCameraIndex = 0;

        }
        if (Input.GetKeyDown(secondCameraKey))
        {

            // Saltamos a cámara 1
            // SwitchToCinemachineCamera(1);
            CurrentActiveCameraIndex = 1;

        }
        if (Input.GetKeyDown(thirdCameraKey))
        {

            // Saltamos a cámara 2
            // SwitchToCinemachineCamera(2);
            CurrentActiveCameraIndex = 2;

        }
        if (Input.GetKeyDown(fourthCameraKey))
        {

            // Saltamos a cámara 3
            // SwitchToCinemachineCamera(3);
            CurrentActiveCameraIndex = 3;

        }
        if (Input.GetKeyDown(fifthCameraKey))
        {

            // Saltamos a cámara 4
            // SwitchToCinemachineCamera(4);
            CurrentActiveCameraIndex = 4;

        }

    }


    void SwitchToCinemachineCamera()
    {

        // Recorrer la lista entera de Cinemachine cameras
        for(int i = 0; i < allVirtualCamerasList.Count; ++i)
        {


            if(i == CurrentActiveCameraIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la prioridad a 1
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