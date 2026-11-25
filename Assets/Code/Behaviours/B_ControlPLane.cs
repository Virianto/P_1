
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

        float mouseX = inputManager.MouseX;
        float mouseY = inputManager.MouseY;
        float keyboardInput = inputManager.KeyboardRoll;

        // 1. Acumular desplazamiento del ratón
        targetPitch += mouseY * mouseSensitivity;
        targetRoll -= mouseX * mouseSensitivity;

        targetPitch = Mathf.Clamp(targetPitch, -maxPitch, maxPitch);
        targetRoll = Mathf.Clamp(targetRoll, -maxRoll, maxRoll);

        // 2. Control Q/E
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

        // 4. Giro horizontal
        float turnAmount = Mathf.Sin(currentRoll * Mathf.Deg2Rad);

        currentYaw -= turnAmount * turnSpeed * dt;

        // 5. Rotaciones
        Quaternion pitchRotation = Quaternion.AngleAxis(
            currentPitch, Vector3.right
        );

        Quaternion yawRotation = Quaternion.AngleAxis(
            currentYaw, Vector3.up
        );

        Quaternion rollRotation = Quaternion.AngleAxis(
            currentRoll, Vector3.forward
        );

        transform.rotation =
            yawRotation * pitchRotation * rollRotation;

        // 6. Avanzar
        transform.position -=
            transform.forward * Speed * dt;
    }
}
