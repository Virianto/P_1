using System;
using UnityEngine;

// PRIMER BLOQUE - Scriptable Object
/// <summary>
/// Me permite crear una representación serializada de una clase en el edito de Unity
/// </summary>

[CreateAssetMenu(fileName = "SingleDaytimeConfig", menuName = "Scriptable Objects/Single Daytime", order = 1)]
public class SO_DaytimeConfig : ScriptableObject
{

    public D_SingleDaytime configData;

}

// SEGUNDO BLOQUE - Enumerado público (Accesorio)

public enum Hour
{
    Midnight,
    Midday,
    Morning,
    Twilight
}

// TERCER BLOQUE - Estructura de datos

[Serializable]
public struct D_SingleDaytime
{
    // Introducir todas las variables que quiero preconfigurar

    [Header("Day Time")]
    public Hour hour;

    [Space(5)]
    [Header("Main Directional Light Data")]

    public Color mainLightColor;
    public float mainLightIntensity;

    [Space(5)]
    [Header("Skybox Material Data")]

    public float sunSize;
    public Color skyColor;
    public Color groundColor;
}