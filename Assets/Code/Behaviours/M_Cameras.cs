
using Unity.Cinemachine;
using System.Collections.Generic;
using UnityEngine;
// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class M_Camerascs : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    List<CinemachineCamera> allVirtualCameraList = new();
    int _currentActiveCameraIndex = 0;
    public int CurrentActiveCameraIndex 
    { 
   
        get { return _currentActiveCameraIndex; }
       set 
        { 
            
            
            _currentActiveCameraIndex = value;
            SwitchToCinemachineCamera(_currentActiveCameraIndex);
        }
    }


    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;


    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;

    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;

    [SerializeField]
        KeyCode fiveCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode antoniolobatoCameraKey = KeyCode.Alpha5;

    #endregion


    #region METHODS
    void Update()
    {
        if (Input.GetKeyDown(firstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }

        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 1;
        }


        if (Input.GetKeyDown(secondCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }

        if (Input.GetKeyDown(fourthCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(fiveCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }
        if (Input.GetKeyDown(antoniolobatoCameraKey))
        {
            CurrentActiveCameraIndex = 5;
        }
    }
    void SwitchToCinemachineCamera(int newIndex)
    {

        for(int i= 0; i<allVirtualCameraList.Count; ++i)
        {
            if(i == newIndex )
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
