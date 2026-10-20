using System;
using Unity.Collections;
using UnityEngine;

public class BasicPlayer : MonoBehaviour
{
    [SerializeField][Range(0, 20)] float playerSpeed = 1;
    [SerializeField][Range(0, 200)] float rotationSpeed = 1;
    float movigRotation;

    void Update() //comprueba si el judador ha pulsado las teclas verticales
    {

        Vector2 movingDirection = Vector2.zero; // Vector2 es ----> (0, 0)

        movigRotation = 0;

        movingDirection.x = Input.GetAxisRaw("Horizontal");
        movingDirection.y = Input.GetAxisRaw("Vertical");

        Vector3 finalMoment = new Vector3(movingDirection.x, 0, movingDirection.y);
        finalMoment *= Time.deltaTime;
        finalMoment *= playerSpeed;
        transform.Translate(finalMoment);

        if (Input.GetKey(KeyCode.Q))
        {
            movigRotation = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            movigRotation = 1;
        }


        Vector3 finalRotation = new Vector3(0, movigRotation, 0);
        finalRotation *= Time.deltaTime;
        finalRotation *= rotationSpeed;
        transform.Rotate(finalRotation);



        //Debug.LogFormat("en horizontal tengo {0} en vertical tengo {1}", movingDirection.x, movingDirection.y);

    }


}
