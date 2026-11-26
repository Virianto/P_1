using UnityEngine;

/// <summary>
/// * Referencia al skybox actual
/// * Referencia a una config de escena
/// * Métodos para aplicar la configuración a la escena
/// </summary>
public class M_Daytime : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    Light mainDirectionalLight;

    [SerializeField]
    SO_DaytimeConfig daytimeConfig;

    #endregion


    #region METHODS
    void OnEnable()
    {
        // Necesito coger una referencia al Skybox material
        Material currentSkybox = RenderSettings.skybox;

        // Necesito desenvolver esos datos al objetivo q correspondan
        D_singleDaytime currentConfigData = daytimeConfig.configData;
        
        // Necesito aplicar esos datos al objetivo q corresponda
        ApplyConfigData(currentSkybox, currentConfigData);
    }

    void ApplyConfigData(Material skybox, D_singleDaytime data)
    {
        // Aplicamos cambios sobre la luz
        mainDirectionalLight.color = data.mainLightColor;
        mainDirectionalLight.intensity = data.mainLightIntensity;

        // Aplicamos cambios sobre el skybox
        skybox.SetFloat("_SunSize", data.sunSize);
        skybox.SetColor("_SkyTint", data.skycolor);
        skybox.SetColor("_GroundColor", data.groundColor);
    }
    #endregion
}
