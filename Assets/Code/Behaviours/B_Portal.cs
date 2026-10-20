using UnityEngine;

public class B_Portal : MonoBehaviour
{
    // Esta clase se va a ocupar de detectar objetos que pasen por su Trigger

    #region ATTRIBUTES

    // Referencia a mi componente Collider
    [SerializeField]
    Collider portalCollider;

    [SerializeField]
    ParticleSystem waterfall_PS;

    [SerializeField]
    [Range(0, 10)]
    int waterfallPressure = 1;

    [SerializeField]
    Color waterfallColor = Color.aquamarine;

    #endregion

    #region METHODS

    // Detectar que algo ha activado mi collider y reaccionar

    void Update()
    {
        waterfall_PS.startColor = waterfallColor;
        waterfall_PS.Emit(waterfallPressure); 
    }

    void OnTriggerEnter(Collider other)
    {
        //waterfall_PS.Play();
    }

    void OnTriggerStay(Collider other)
    {
        //waterfall_PS.Emit(100);
    }

    void OnTriggerExit(Collider other)
    {
        //waterfall_PS.Stop();
    }

    #endregion
}
