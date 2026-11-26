using System;
using UnityEngine;

// * PRIMER BLOQUE *
// Scriptable Object

/// <summary>
/// Permite crear una representación serializada de una clase en el editor de Unity
/// </summary>

[CreateAssetMenu(fileName = "SingleDayTimeConfig", menuName = "ScriptableObjects / SingleDayTime", order = 1)]

public class SO_DayTimeConfig : ScriptableObject
{
    public D_SingleDayTime configData;
}

// * SEGUNDO BLOQUE * (OPCIONAL)
// Enumerado público

public enum Hour
{
    Midnight,
    Midday,
    Morning,
    Twilight
}


// * TERCER BLOQUE *
// Estructura de datos

[Serializable]
public struct D_SingleDayTime
{
    // Introducir todas las variables que queremos preconfigurar
    [Header("Day Time")]

    public Hour hour;

    [Space(5)]

    [Header("Main Directional Light Data")]

    public Color mainLightcolor;
    public float mainLightIntensity;

    [Space(5)]

    [Header("Skybox Material Data")]

    public float sunSize;
    public Color skyColor;
    public Color groundColor;

}