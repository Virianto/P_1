using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES
    public float rotationSpeed = 5f;
    public float rollSpeed = 45f;
    public float Speed = 20f;
    public float minSpeed = 20f;
    public float maxSpeed = 100f;
    public float accelerationSensitivity = 50f; // Qué tan rápido cambia la velocidad con el scroll

    [SerializeField]
    [Range(1, 100)]
    float maxLifePoints = 20;
    float currentLifePoints;


    [Range(0, 180)]
    public float angularSpeed = 90;

    [SerializeField]
    KeyCode hNegativeTiltKey = KeyCode.E;

    [SerializeField]
    KeyCode hPositiveTiltKey = KeyCode.Q;

    #endregion
    #region METHODS

    void Awake()
    {
        M_ManagerCanvasAvion.Instance.CurrentSpeed(Speed);
        // Me aseguro de que el jugador empieza el nivel con toda la vida siempre
        currentLifePoints = maxLifePoints;
    }
    private void Update()
    {
        if (Input.GetKey(hNegativeTiltKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(hPositiveTiltKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            // Sumar el scroll y limitar la velocidad entre el mínimo y el máximo
            Speed += scrollInput * accelerationSensitivity;
            Speed = Mathf.Clamp(Speed, minSpeed, maxSpeed);
        }

        // 2. Avanzar siempre hacia adelante con la velocidad actual
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        // 2. Obtener posición del ratón normalizada (-1 a 1 desde el centro de la pantalla)
        Vector3 mousePos = Input.mousePosition;
        float halfWidth = Screen.width / 2f;
        float halfHeight = Screen.height / 2f;

        float x = (mousePos.x - halfWidth) / halfWidth; // -1 (izq) a 1 (der)
        float y = (mousePos.y - halfHeight) / halfHeight; // -1 (abajo) a 1 (arriba)

        // Limitar valores por seguridad
        x = Mathf.Clamp(x, -1f, 1f);
        y = Mathf.Clamp(y, -1f, 1f);

        // 3. Calcular rotación de pitch (cabeceo) y yaw (guiñada)
        float pitch = -y * rotationSpeed;
        float yaw = x * rotationSpeed;
        float roll = -x * rollSpeed; // Inclinación lateral realista

        // Aplicar rotación al avión
        Quaternion targetRotation = Quaternion.Euler(pitch * 10f, transform.localEulerAngles.y + yaw, roll);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    public void CurrentSpeed(float currentSpeed)
    {
        Speed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        M_ManagerCanvasAvion.Instance.CurrentSpeed(Speed);
    }

    public void CurrentStatusFloor(string status)
    {
       M_ManagerCanvasAvion.Instance.PlaneStatusChange(status);
    }

    public void ModifyPlayerLife(float amount)
    {
        currentLifePoints += amount;
        Debug.Log("mi vida es " + currentLifePoints);
        M_ManagerCanvasAvion.Instance.PlayerLifeChanged(currentLifePoints / maxLifePoints);
    }
    public void ModifyTimeLeft(float amount)
    {
        M_ManagerCanvasAvion.Instance.PlayerTimeChanged(amount);
    }
    #endregion
}

