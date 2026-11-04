using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;

/// <summary>
/// Propósito de esta clase
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

    int currentActiveCameraIndex = 0;
    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        //como se comporta la lectura
        get { 
            return currentActiveCameraIndex; 
            
        }
        
        //como se comporta la escritura
        set { 
            //modifico el valor de mi variable privada
            _currentActiveCameraIndex = value;

            //utilizo el nuevo valor de forma automática
            SwitchToCinemachineCamera();

        }
    }
    #endregion

    #region METHODS
    void Update()
    {
        //detectar input del usuario para cambiar la camara principal
        if(Input.GetKeyDown(firstCameraKey))
        {
            //saltamos camara 1
            CurrentActiveCameraIndex = 0;
        }
        else if(Input.GetKeyDown(secondCameraKey))
        {
            //saltamos camara 2
            CurrentActiveCameraIndex = 1;
        }
        else if(Input.GetKeyDown(thirdCameraKey))
        {
            //saltamos camara 3
            CurrentActiveCameraIndex = 2;
        }
        else if(Input.GetKeyDown(fourthCameraKey))
        {
            //saltamos camara 4
            CurrentActiveCameraIndex = 3;
        }
    }

    void SwitchToCinemachineCamera()
    {
        //recorrer la lista entera del cinemachine cameras
        for (int i =0; i< allVirtualCamerasList.Count; i++)
        {
            if (i == CurrentActiveCameraIndex)
            {
                //para cada cámara, si es la del indice que quiero que le cambie la prioridad a 1
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                // si no es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }
    #endregion
}
