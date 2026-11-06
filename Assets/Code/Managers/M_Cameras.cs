
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

/// <summary>
///tener referemncias a todas las camara virtuales de la escena
///detectar imput de usuario para saltar de una camara a otra 
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]

    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameaKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;

    [SerializeField]
    KeyCode cuartiaryCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode quintaCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode sextaCameraKey = KeyCode.Alpha5;

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }

        set 
        { 
            _currentActiveCameraIndex = value; 
            SwichToCinemachineCamera();
        }
    }
    #endregion


    #region METHODS 
    private void Update()
    {
        if(Input.GetKeyDown(firstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }
    
        if(Input.GetKeyDown(secondCameaKey))
        {
            CurrentActiveCameraIndex = 1;
        }
    
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }
        if (Input.GetKeyDown(cuartiaryCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(quintaCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }

        if (Input.GetKeyDown(sextaCameraKey))
        {
            CurrentActiveCameraIndex = 5;
        }
    }

    void SwichToCinemachineCamera ()
    {
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i  == CurrentActiveCameraIndex)
            
            {
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                allVirtualCamerasList[i].Priority = 0;
            }
        }
     
        

    }
    #endregion
}
