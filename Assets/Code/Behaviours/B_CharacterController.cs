using System;
using Unity.VisualScripting;
using UnityEngine;

public class B_CharacterController : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    [Range(0,50)]
    float playerSpeed = 1;

    [SerializeField]
    [Range(0, 50)]
    float roatationSpeed = 1;

    public int yellowCoinsCollected = 0;
    public int orangeCoinsCollected = 0;
    public int blueCoinsCollected = 0;

    public Boolean allowedYellow = false;
    public Boolean allowedBlue = false;
    public Boolean allowedOrange = false;

    public Boolean metaYellow = false;
    public Boolean metadBlue = false;
    public Boolean metaOrange = false;
    public float rotationSpeed = 200f;

    #endregion

    #region METHODS

    private void Update()
    {
        Vector2 movingDirection = Vector2.zero;
        float movingRotation = 0;

        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Rota la cámara en los ejes X e Y
            transform.Rotate(Vector3.up, mouseX, Space.World);
            transform.Rotate(Vector3.right, -mouseY, Space.Self);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            movingRotation = -1;
        }

        if (Input.GetKey(KeyCode.E))
        {
            movingRotation = 1;
        }

        Vector3 finalMovemnt =  new Vector3(movingDirection.x, 0, movingDirection.y);
        finalMovemnt *= Time.deltaTime;
        finalMovemnt *= playerSpeed;

        transform.Translate(finalMovemnt);

        transform.Rotate(new Vector3(0, (movingRotation*Time.deltaTime)*roatationSpeed, 0));
    }
    #endregion
}
