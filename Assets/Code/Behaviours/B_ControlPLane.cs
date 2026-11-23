
using UnityEngine;
using UnityEngine.InputSystem;

public class B_ControlPLane : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 20f;

    [Header("Mouse Aim")]
    [SerializeField] private float mouseSensitivity = 0.15f;
    [SerializeField] private float maxPitch = 60f;
    [SerializeField] private float maxRoll = 80f;

    [Header("Flight")]
    [SerializeField] private float rotationSpeed = 3f;

    [Header("Keyboard Flight")]
    [SerializeField] private KeyCode hNegativeTiltKey = KeyCode.E;
    [SerializeField] private KeyCode hPositiveTiltKey = KeyCode.Q;
    [SerializeField] private float keyboardRollAmount = 20f;

    [Header("Turning")]
    [SerializeField] private float turnSpeed = 30f;

    private float mouseX;
    private float mouseY;

    private float targetPitch;
    private float targetRoll;

    private float currentPitch;
    private float currentRoll;
    private float currentYaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Input Action: Pitch
    public void OnPicth(InputValue value)
    {
        mouseY = value.Get<float>();
    }

    // Input Action: Roll
    public void OnRoll(InputValue value)
    {
        mouseX = value.Get<float>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        // 1. Mouse Aim
        targetPitch -= mouseY * mouseSensitivity;
        targetRoll -= mouseX * mouseSensitivity;

        targetPitch = Mathf.Clamp(
            targetPitch, -maxPitch, maxPitch
        );

        targetRoll = Mathf.Clamp(
            targetRoll, -maxRoll, maxRoll
        );

        // 2. Controles Q/E
        float keyboardInput = 0f;

        if (Input.GetKey(hNegativeTiltKey))
            keyboardInput -= 1f;

        if (Input.GetKey(hPositiveTiltKey))
            keyboardInput += 1f;

        float desiredRoll = Mathf.Clamp(
            targetRoll + keyboardInput * keyboardRollAmount,
            -maxRoll,
            maxRoll
        );

        // 3. Suavizar rotaciones
        currentPitch = Mathf.Lerp(
            currentPitch,
            targetPitch,
            dt * rotationSpeed
        );

        currentRoll = Mathf.Lerp(
            currentRoll,
            desiredRoll,
            dt * rotationSpeed
        );

        // 4. Calcular giro horizontal
        float turnAmount = Mathf.Sin(
            currentRoll * Mathf.Deg2Rad
        );

        currentYaw -= turnAmount * turnSpeed * dt;

        // 5. Crear rotaciones independientes
        Quaternion pitchRotation = Quaternion.AngleAxis(
            currentPitch, Vector3.right
        );

        Quaternion yawRotation = Quaternion.AngleAxis(
            currentYaw, Vector3.up
        );

        Quaternion rollRotation = Quaternion.AngleAxis(
            currentRoll, Vector3.forward
        );

        // 6. Aplicar orientación completa
        transform.rotation =
            yawRotation * pitchRotation * rollRotation;

        // 7. Avanzar siguiendo el morro
        transform.position +=
            transform.forward * Speed * dt;

        // 8. Consumir movimiento del ratón
        mouseX = 0f;
        mouseY = 0f;
    }
}
