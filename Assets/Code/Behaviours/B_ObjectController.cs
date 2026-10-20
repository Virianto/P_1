using UnityEngine;

public class B_ObjectController : MonoBehaviour
{
    #region ATTRIBUTES

    // Exponer valores numéricos para controlar con un Slider:
    // Escala general
    
    float scaleFactor = 1;

    // Posición vertical
    
    float verticalPosition = 0;

    // Rotación en torno al eje Y
    
    float horizontalRotation = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        verticalPosition = transform.position.y;
    }

    public void UpdateScaleFactor(float sliderValue)
    {
        scaleFactor = sliderValue;        
    }

    public void UpdateVerticalPosition(float sliderValue)
    {
        verticalPosition = sliderValue;
    }

    public void UpdateHorizontalRotation(float sliderValue)
    {
        horizontalRotation = sliderValue;
    }

    void Update()
    {        
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        transform.position = new Vector3(transform.position.x, verticalPosition, transform.position.z);

        transform.Rotate(0, horizontalRotation, 0);
    }

    #endregion
}
