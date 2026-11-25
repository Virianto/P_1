using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class EthanPlaneController : MonoBehaviour
{
    [Range(5, 400)] public float planeSpeed; //Normalmete 5
    [Range(0, 180)] public float angularSpeed = 100;
    float boostSpeedToggle = 200;
    public event Action<float> OnPlayerSpeedChanged;

    float upDownValue;
    float leftRightValue;
    float tiltValue;
    public bool boost = false;

    void OnUpDown(InputValue value)
    {
        upDownValue = value.Get<float>();
    }
    void OnLeftRight(InputValue value)
    {
        leftRightValue = value.Get<float>();
    }
    void OnTiltLeftRight(InputValue value)
    {
        tiltValue = value.Get<float>();
    }
    //void OnBoost()
    //{
    //    boost = !boost;
    //    OnBoostAction(boostSpeedToggle);
    //    //M_FlightSim.Instance.StopCoroutine(M_FlightSim.Instance.SwitchSpeedCourutine(0));
    //    M_FlightSim.Instance.StopAllCoroutines();
    //}

    void OnBoost()
    {
        boost = !boost;
        OnBoostAction(boostSpeedToggle);
        M_FlightSim.Instance.StopSpeedCoroutine();
    }

    public void OnBoostAction(float boostSpeed)
    {
        if (boost)
        {
            planeSpeed = boostSpeed;
            M_FlightSim.Instance.ChangeCam(2);
        }
        else
        {
            planeSpeed = 50;
            M_FlightSim.Instance.ChangeCam(0);
        }
    }


    void Update()
    {
        OnPlayerSpeedChanged?.Invoke(planeSpeed);
        transform.position += transform.forward * Time.deltaTime * planeSpeed;
        
        if (upDownValue <= 0) //(W)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }
        if (upDownValue >= 0) //(S)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * angularSpeed);
        }
        if(leftRightValue <= 0) //(A)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * angularSpeed);
        }
        if(leftRightValue >= 0) //(D)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * angularSpeed);
        }
        if(tiltValue <= 0) //(Q)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed * 2);
        }
        if(tiltValue >= 0) //(E)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * angularSpeed * 2);
        }  
    }
}
