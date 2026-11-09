using Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_Cameras : Code.Utils.Singleton<M_Cameras>
{
    #region ATTRIBUTES

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    #endregion
    #region METHODS

    public void EnterRingDamage(int index)
    {
        StartCoroutine(EnterRingCount(index));
    }

    public void EnterRingSpeed(int index)
    {
        StartCoroutine(EnterRingCount(index));
    }

    IEnumerator EnterRingCount(int index)
    {
        allVirtualCamerasList[0].Priority = 0;
        allVirtualCamerasList[index].Priority = 1;
        yield return new WaitForSeconds(1);
        allVirtualCamerasList[index].Priority = 0;
        allVirtualCamerasList[0].Priority = 1;
    }

    #endregion
}

