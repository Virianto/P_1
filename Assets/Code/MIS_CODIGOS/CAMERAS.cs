using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// TENER REFERENCIAS A TODAS LAS CAMARAS VIRTUALES 
/// DETECTAR INPUT DEL USUARIO PARA CAMBIARLAS
/// </summary>
public class CAMERAS : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    List<CinemachineCamera> allVirtualCameraList = new();

    [SerializeField]
    KeyCode firtstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode thirdCameraKey = KeyCode.Alpha2;

    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;
    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }

        set
        {
            //modifico el valor de mi variable privada
            _currentActiveCameraIndex = value;
            SwitchToCinemachineCamera(_currentActiveCameraIndex);//
        }
    }
    #endregion

    #region METHODS
     void Update()
    {
        if(Input.GetKeyDown(firtstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }


        if (Input.GetKeyDown(secondCameraKey))
        {
            CurrentActiveCameraIndex = 1;
        }

        if (Input.GetKeyDown(thirdCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }

        if (Input.GetKeyDown(fourthCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }







 











    }

    void SwitchToCinemachineCamera(int newIndex)
    {
        for(int i = 0;i<allVirtualCameraList.Count;++i)
        {
            if (i==newIndex)
            {
                allVirtualCameraList[i].Priority = 1;
            }
            else
            {
                allVirtualCameraList[i].Priority = 0;
            }
        }


    }
    #endregion
}
