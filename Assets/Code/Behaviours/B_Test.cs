using UnityEngine;

public class B_Test : MonoBehaviour
{
    #region ATTRIBUTES

    // Variables dentro de mi código [datos propios de la clase]

    [SerializeField]
    float objectVelocity = 2;

    // VARIABLES PROPIAS DE UNITY

    Transform myOwnTransform;

    [SerializeField]
    Vector3 newPosition;

    [SerializeField]
    Vector3 newScale;
    
    #endregion

    #region METHODS

    // Los métodos son la funcionalidad en el código

    // MÉTODOS PROPIOS DE UNITY PARA EJECUCIÓN EN ESCENA
       
    // Primer método que se lanza al iniciar una escena
    public void Awake()
    {
        // 'transform' aquí accede directamente al Transform que tiene mi objeto asociado
        myOwnTransform = transform;
    }

    // Segundo método que se lanza al iniciar escena O al activar mi objeto
    public void OnEnable()
    {
        //Debug.Log("Soy el OnEnable");
    }

    // Método que se lanza en el primer frame tras iniciar mi escena
    public void Start()
    {
        
    }

    // Todo lo que yo escriba dentro de Update se ejecuta UNA vez cada frame de mi juego
    public void Update()
    {
        // Este Vector3 va a morir cuando Update haya acabado y volverá a nacer en el siguiente
        Vector3 lastPosition = myOwnTransform.position;

        // Modificar mi nuevo Vector3 temporal
                
        lastPosition.z += objectVelocity * Time.deltaTime;
        
        // Reasignar mi Vector3 temporal a mi variable global (myOwnTransform) para que haga algo
        myOwnTransform.position = lastPosition;
    }

    // Método que se lanza cada vez que desactivo mi objeto asociado
    public void OnDisable()
    {
        //Debug.Log("Soy el OnDisable");
    }

    // Método que se lanza justo antes de destruir mi objeto asociado de la escena
    public void OnDestroy() 
    {
        //Debug.Log("Soy el OnDestroy");
    }

    #endregion
}
