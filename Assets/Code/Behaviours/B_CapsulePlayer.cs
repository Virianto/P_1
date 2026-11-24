using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Crear una referencia al AnimatorController
/// * Vincular variables de movimiento con parámetros del Animator Controller
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D rb_2D;

    [SerializeField]
    Animator animController;

    [SerializeField]
    //M_SwingPoints swingPointsManager;

    [Header("EDITABLE VALUES")]

    //[SerializeField]
    [Range(1, 30)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 30)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 15)]
    float moveSpeed = 3;

    float movementValue;
    float originalXScale;

    // Variable para controlar hacia dónde enfoco acciones y conectores
    float facingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrouching = false;
    bool isSwinging = false;

    #endregion

    #region METHODS

    void Awake()
    {
        originalXScale = transform.localScale.x;
    }

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();               

        if (movementValue != 0) 
        {
            facingDirection = movementValue > 0 ? 1 : -1;

            transform.localScale = new Vector3(
                originalXScale * facingDirection,
                transform.localScale.y,
                transform.localScale.z);
        }        
    }

    void FixedUpdate()
    {
        if (!isDashing && !isSwinging && !isCrouching)
        {
            rb_2D.linearVelocityX = movementValue * moveSpeed;
            animController.SetFloat("HorizontalSpeed", Mathf.Abs(rb_2D.linearVelocityX));            
        }

        // Control de velocidad vertical para modificar animaciones:
        animController.SetFloat("VerticalSpeed", rb_2D.linearVelocityY);
    }

    void OnJump(InputValue value)
    {
        // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
        if (isGrounded && !isCrouching)
        {
            rb_2D.linearVelocityY = jumpForce;
        }
        else if (!isDoubleJumping && !isCrouching)
        {
            rb_2D.linearVelocityY = jumpForce;
            isDoubleJumping = true; 
        }
    }

    void OnDash()
    {
        if (!isDashing && !isCrouching)
        {
            StartCoroutine(DashRoutine());
        }         
    }

    IEnumerator DashRoutine()
    {
        // Empujar al jugador con la fuerza indicada
        rb_2D.linearVelocityX = dashForce * facingDirection;
        // Modificar el booleano de estado
        isDashing = true;
        // Esperar un tiempo X
        yield return new WaitForSeconds(0.5f);
        // Modificar el booleano de estado
        isDashing = false;
    }

    void OnCrouch(InputValue value)
    {
        isCrouching = value.isPressed;

        animController.SetBool("IsCrouching", isCrouching);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
            animController.SetBool("IsGrounded", isGrounded);
        }        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            animController.SetBool("IsGrounded", isGrounded);
        }        
    }

    //void OnSwing(InputValue value)
    //{
        //isSwinging = value.isPressed;

       // if (isSwinging)
       // {            
        //    swingPointsManager.ConnectPlayerToJoint();
       //}
       // else
       // {
           // swingPointsManager.DisconnectPlayerFromJoint();
       // }        
    //}

    #endregion
}
