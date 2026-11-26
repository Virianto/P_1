
using UnityEngine;

public class EH_M_Daytime : MonoBehaviour
{
    [SerializeField] Light mainDirectionalLight;

    [SerializeField] SO_EthanDayTimeConfig daytimeConfig;

    void OnEnable()
    {
        Material currentSkybox = RenderSettings.skybox;
        D_singleDaytime currentConfigData = daytimeConfig.configData;
        ApplyConfigData(currentSkybox, currentConfigData);
    }

    void ApplyConfigData(Material skybox, D_singleDaytime data)
    {
        mainDirectionalLight.color = data.mainLightColor;
        mainDirectionalLight.intensity = data.mainLightIntensity;

        skybox.SetFloat("_SunSize", data.sunSize);
        skybox.SetColor("_SkyTint", data.skyColor);
        skybox.SetColor("_GroundColor", data.GroundColor);
    }
}
