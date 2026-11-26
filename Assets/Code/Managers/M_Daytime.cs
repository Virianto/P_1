using UnityEngine;

/// <summary>
/// Referencia al skybox actual
/// Referencia a una configuración de escena
/// Métodos para aplicar la configuración de escena
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

    private void OnEnable()
    {
        //Referencia a Skybox material
        Material curretSkybox = RenderSettings.skybox;

        //Devolver los datos de configuración
        D_SingleDaytime currentConfigData = daytimeConfig.configData;

        //Aplicar datos al objeto corespondiente
        ApplyConfigData(curretSkybox, currentConfigData);
    }

    void ApplyConfigData(Material skybox, D_SingleDaytime data)
    {
        //Aplicamos cambios sobre la luz
        mainDirectionalLight.color = data.mainLightColor;
        mainDirectionalLight.intensity = data.mainLightIntensity;

        //Aplicamos cambios sobre skybox
        skybox.SetFloat("_SunSize", data.bodySize);
        skybox.SetColor("_SkyTint", data.skyColor);
        skybox.SetColor("_GroundColor", data.groundColor);
    }

    #endregion
}
