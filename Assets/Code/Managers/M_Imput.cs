using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class M_Imput : MonoBehaviour
{
    #region ATTRIBUTES


    #endregion
    [SerializeField]
    KeyCode palaIzquierda = KeyCode.W;

    [SerializeField]
    KeyCode palaDerecha = KeyCode.R;

    [SerializeField]
    KeyCode pouncher = KeyCode.E;

    [SerializeField]
    HingeJoint2D palaI;

    [SerializeField]
    HingeJoint2D palaD;

    [SerializeField]
    SliderJoint2D empuja;

    #region METHODS 

    void Update()
    {
    palaI.useMotor = Input.GetKey(palaIzquierda);
    palaD.useMotor = Input.GetKey(palaDerecha);
    empuja.useMotor = Input.GetKey(pouncher);

    }

    #endregion
}
