using System;
using UnityEngine;

/// <summary>
/// Me permite crear una representación serealizada deuna clase en el editor de Unity
/// </summary>
[CreateAssetMenu(fileName = "SingleDaytimeConfig", menuName = "Scriptable Objects/SingleDaytime", order = 1)]
public class SO_DaytimeConfig : ScriptableObject
{
    public D_singleDaytime configData;

}


// SEGUNDO BLQUE - Enumerado público
public enum Hour
{
    Midnight,
    Midday,
    Morning,
    Twilight
}

// TERCER BLOQUE - Estructura de datos
[Serializable]
public struct D_singleDaytime
{
    // Introducir todas las variables q quiero preconfigurar
    [Header("Day Time")]

    public Hour hour;

    [Space(5)]

    [Header("Main Directional Light Data")]
    public Color mainLightColor;
    public float mainLightIntensity;

    [Space(5)]


    [Header("Skybox Material Data")]

    public float sunSize;
    public Color skycolor;
    public Color groundColor;
}
