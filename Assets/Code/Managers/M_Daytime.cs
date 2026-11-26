using Unity.VisualScripting;
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
    SO_DaytimeConfig daytimeConfig;


    #endregion



    #region METHODS

    void OnEnable()
    {
        // Necesito coger una referencia al Skybox material

        Material currentSkybox = RenderSettings.skybox;

        // Necesito desenvolver los datos de la configuración

        D_SingleDaytime currentConfigData = daytimeConfig.configData;

        // Necesito aplciar esos datos la objetivo que correspondan
        ApplyConfigData(currentSkybox, currentConfigData);

    }

    void ApplyConfigData(Material skybox, D_SingleDaytime data)
    {
        // Aplicamos cambios sobre la luz

        mainDirectionalLight.color = data.mainLightColor;
        mainDirectionalLight.intensity = data.mainLightIntensity;

        // Aplicamos cambios sobre el skybox
        skybox.SetFloat("_SunSize", data.sunSize);
        skybox.SetColor("_SkyTint", data.skyColor);
        skybox.SetColor("_GroundColor", data.groundColor);

    }

    #endregion
}