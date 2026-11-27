using UnityEngine;

/// <summary>
/// * Referencia al skybox actual
/// X Referencia a una configuración de escena
/// * Métodos para aplicar la configuración a la escena
/// </summary>
public class M_Daytime : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Light mainDirectionalLight;

    [SerializeField]
    SO_DaytimeConfig dayTimeConfig;

    #endregion

    #region METHODS

    void OnEnable()
    {
        // Necesito coger una referencia al Skybox material
        Material currentSkybox = RenderSettings.skybox;

        // Necesito desenvolver los datos de configuración
        D_SingleDaytime currentConfigData = dayTimeConfig.configData;

        // Necesito aplicar esos datos al objetivo que correspondan
        ApplyConfigData(currentSkybox, currentConfigData);
    }

    void ApplyConfigData(Material skybox, D_SingleDaytime data)
    {        
        mainDirectionalLight.color = data.mainLightColor;
        mainDirectionalLight.intensity = data.mainLightInstensity;
                
        skybox.SetFloat("_SunSize", data.sunSize);
        skybox.SetColor("_SkyTint", data.skyColor);
        skybox.SetColor("_GroundColor", data.groundColor);
    }

    #endregion
}
