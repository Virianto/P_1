using UnityEngine;

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
    [SerializeField] private float keyboardRollAmount = 20f;

    [Header("Turning")]
    [SerializeField] private float turnSpeed = 30f;

    private float targetPitch;
    private float targetRoll;

    private float currentPitch;
    private float currentRoll;
    private float currentYaw;

    private M_PlayerInput inputManager;

    private void Start()
    {
        inputManager = M_PlayerInput.Instance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        // 1. Obtener inputs del InputManager
        float mouseX = inputManager.MouseX;
        float mouseY = inputManager.MouseY;
        float keyboardInput = inputManager.KeyboardRoll;

        // 2. Mouse Aim
        targetPitch -= mouseY * mouseSensitivity;
        targetRoll -= mouseX * mouseSensitivity;

        targetPitch = Mathf.Clamp(
            targetPitch, -maxPitch, maxPitch
        );

        targetRoll = Mathf.Clamp(
            targetRoll, -maxRoll, maxRoll
        );

        // 3. Controles Q/E
        float desiredRoll = Mathf.Clamp(
            targetRoll + keyboardInput * keyboardRollAmount,
            -maxRoll,
            maxRoll
        );

        // 4. Suavizar rotaciones
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

        // 5. Calcular giro horizontal
        float turnAmount = Mathf.Sin(
            currentRoll * Mathf.Deg2Rad
        );

        currentYaw -= turnAmount * turnSpeed * dt;

        // 6. Crear rotaciones independientes
        Quaternion pitchRotation = Quaternion.AngleAxis(
            currentPitch, Vector3.right
        );

        Quaternion yawRotation = Quaternion.AngleAxis(
            currentYaw, Vector3.up
        );

        Quaternion rollRotation = Quaternion.AngleAxis(
            currentRoll, Vector3.forward
        );

        // 7. Aplicar orientación completa
        transform.rotation =
            yawRotation * pitchRotation * rollRotation;

        // 8. Avanzar siguiendo el morro
        transform.position +=
            transform.forward * Speed * dt;
    }
}