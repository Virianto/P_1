using UnityEngine;

/// <summary>
/// * Generar instancias del prefab "EvilBalloon" en ubicaciones aleatorias
/// * Gestionar el ciclo de vida de los globos
/// * NO CREAR MÁS GLOBOS SI YA HAY (límite editable) EN ESCENA
/// </summary>
public class M_Balloons : MonoBehaviour
{
    #region ATTRIBUTES
    
    // Referencia al prefab
    [SerializeField] GameObject balloon;
    // Límite de enemigos simultáneos en escena
    [SerializeField] int maxBalloons = 5;
    // Límites de espacio para ubicar cada nuevo prefab

    #endregion

    #region METHODS

    // MétodoS de generación de nuevo globo (Start + Rutina + Método void)

    #endregion
}
