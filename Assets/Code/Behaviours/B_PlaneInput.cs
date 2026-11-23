using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_PlaneInput : MonoBehaviour
{

    #region ATTRIBUTES

    float movementValue;
    float originalXScale;
    float facingDirection = 1;

    bool isTiltedUp = false;
    bool isTiltedDown = false;
    bool isPaningLeft = false;
    bool isPaningRight = false;
    bool isTurbo = false;

    #endregion



    #region METHODS

    void OnTilt(InputValue value)
    {
        movementValue = value.Get<float>();


        if (movementValue != 0)
        {
            facingDirection = movementValue >= 0 ? 1 : -1;

            transform.localScale = new Vector3(
            originalXScale * facingDirection,
            transform.localScale.y, 
            transform.localScale.z);
        }
    }

    void OnPan(InputValue value)
    {
        movementValue = value.Get<float>();


        if (movementValue != 0)
        {
            facingDirection = movementValue >= 0 ? 1 : -1;

            transform.localScale = new Vector3(
            originalXScale * facingDirection,
            transform.localScale.y,
            transform.localScale.z);
        }
    }

    void OnTurbo(InputValue value)
    {

        isTurbo = true;

    }

    #endregion
    }