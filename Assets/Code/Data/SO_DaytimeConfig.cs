using System;
using UnityEngine;

//PRIMER BLOQUE - Scriptable Object

/// <summary>
/// Me permite crear una representación serializada de una clase en el editor
/// </summary>
[CreateAssetMenu(
    fileName = "SingleDaytimeConfig", 
    menuName = "Scriptable Objects/SingleDaytime",
    order = 1)]
public class SO_DaytimeConfig : ScriptableObject
{
    public D_SingleDaytime configData;
}

// SEGUNDO BLOQUE - Enumerado público
public enum Hour
{
    Midnight,
    Noon,
    Morning,
    Twilight
}

// TERCER BLOQUE - Estructura de datos
[Serializable]
public struct D_SingleDaytime
{
    [Header("Day Time")]

    public Hour hour;

    [Space(5)]
    [Header("Main Directional Light Data")]

    public Color mainLightColor;
    public float mainLightIntensity;

    [Space(5)]
    [Header("Skybox Material Data")]

    public float bodySize;
    public Color skyColor;
    public Color groundColor;
}