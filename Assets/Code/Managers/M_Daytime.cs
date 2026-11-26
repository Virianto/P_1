using UnityEngine;


/// <summary>
/// * Referencia al skybox actual
/// * Referencia a una configuración de escena
/// * Métodos para aplicar a la configuración de escena
/// </summary>
public class M_Daytime : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Light mainDirectionalLight;

    [SerializeField]
    SO_DayTimeConfig dayTimeConfig;

    #endregion





    #region METHODS

    private void OnEnable()
    {
        // Referenciar al skybox material
        Material currentSkybox = RenderSettings.skybox;

        // Desenvolver los datos de configuración
        D_SingleDayTime currentConfigData = dayTimeConfig.configData;

        // Aplicar esos datos al objetivo que correspondan
        ApplyConfigData(currentSkybox, currentConfigData);
    }

    void ApplyConfigData(Material skybox, D_SingleDayTime data)
    {
        // Aplicar cambios en la luz
        mainDirectionalLight.color = data.mainLightcolor;
        mainDirectionalLight.intensity = data.mainLightIntensity;

        // Aplicar cambios en el skybox
        skybox.SetFloat("_SunSize", data.sunSize);
        skybox.SetColor("_SkyTint", data.skyColor);
        skybox.SetColor("_GroundColor", data.groundColor);
    }

    #endregion
}