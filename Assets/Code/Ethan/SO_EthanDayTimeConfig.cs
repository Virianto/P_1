using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EthanSingleDaytimeConfig", menuName = "Scriptable Objects/SingleDaytime", order =1)]

public class SO_EthanDayTimeConfig : ScriptableObject
{

    public D_singleDaytime configData;



}


public enum Hour
{
    Midnight, Midday, Morning, Twilight
}

[Serializable] public struct D_singleDaytime
{
    [Header("DAY TIME")]
    public Hour hour;
    [Space(5)]
    [Header("Main Directional light data")]
    public Color mainLightColor;
    public float mainLightIntensity;
    [Space(5)]
    [Header("Skybox MaterialData")]
    public float sunSize;
    public Color skyColor;
    public Color GroundColor;
}