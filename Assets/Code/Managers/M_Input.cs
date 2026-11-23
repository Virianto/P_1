using UnityEngine;

/// <summary>
/// Palas se desactivan y activan con teclado
/// Pulsador se desactiva y activa con teclado
/// </summary>
public class M_Input : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    KeyCode palasKey = KeyCode.Space;
    [SerializeField]
    KeyCode springKey = KeyCode.C;

    [SerializeField]
    HingeJoint2D palaIzq;
    [SerializeField]
    HingeJoint2D palaDrch;

    [SerializeField]
    SliderJoint2D spring;


    #endregion



    #region METHODS
    private void Start()
    {
        
    }

    private void Update()
    {
        

        if (Input.GetKey(palasKey))
        {

            palaIzq.useMotor = true;
            palaDrch.useMotor = true;
        }
        else
        {
            palaIzq.useMotor = false;
            palaDrch.useMotor = false;
        }

        if (Input.GetKey(springKey))
        {
            
            spring.useMotor = true;

        }
        else
        {
            spring.useMotor= false;
        }

    }
    #endregion
}