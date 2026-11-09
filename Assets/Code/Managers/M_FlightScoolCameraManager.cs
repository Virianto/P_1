using Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_FlightScoolCameraManager : Singleton<M_FlightScoolCameraManager>
{

    #region ATTRIBUTES

    public event Action<int> OnHitPlayer;

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();


    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode thirdCameraKey = KeyCode.Alpha2;

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        // Cómo se comporta la lectura
        get { return _currentActiveCameraIndex; }

        //Cómo se comporta la escritura (cambios de la variable)
        set
        {
            // Modifico el valor demi variable privada
            _currentActiveCameraIndex = value;

            // Utilizo el nuevo valor de forma automática
            SwitchToCinemachineCamera();
        }
    }

    #endregion


    #region METHODS


    private void Update()
    {
        if (Input.GetKeyDown(firstCameraKey))
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
    }

    void SwitchToCinemachineCamera()
    {

        for (int a = 0; a < allVirtualCamerasList.Count; a++)
        {

            if (a == CurrentActiveCameraIndex)
            {
                allVirtualCamerasList[a].Priority = 1;
            }
            else
            {
                allVirtualCamerasList[a].Priority = 0;
            }


        }

    }

    public void ChangeToHitCamera(int newCurrentCameraIndex)
    {
        OnHitPlayer?.Invoke(CurrentActiveCameraIndex);
        StartCoroutine(CameraChangeAfterEvent(newCurrentCameraIndex));
    }


    IEnumerator CameraChangeAfterEvent(int newIndex)
    {
        CurrentActiveCameraIndex = newIndex;
        yield return new WaitForSeconds(1);
        CurrentActiveCameraIndex = 0;
    }
    #endregion
}
