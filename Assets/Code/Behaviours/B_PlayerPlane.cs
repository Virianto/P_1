
using System;
using UnityEngine;

/// <summary>
/// mover de manera contante el objeto asocido hacia delante
/// detectac imput pra gira y rotar rl objeto
/// añadir tecla de teletranoprte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    [Range(0, 300)]
    public float speed = 3;

    [Range(0, 180)]
    public float angularspeed = 90;

    [SerializeField]
    KeyCode vNegativeTilKey = KeyCode.W;
    [SerializeField]
    KeyCode vPositiveTilKey = KeyCode.S;

    [SerializeField]
    KeyCode hNegativeTilKey = KeyCode.A;

    [SerializeField]
    KeyCode hPositiveTilKey = KeyCode.D;
    #endregion
    [SerializeField]
    [Range(1, 100)]
    float MaxLifePoints = 20;
    float currentLifePoint = 20;

    float currentSpeedVelocity = 20;

    #region METHODS 

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

            if(Input.GetKey(vNegativeTilKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularspeed);
        }

        if (Input.GetKey(vPositiveTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularspeed);
        }

        if ( Input.GetKey(hNegativeTilKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularspeed);
        }

        if (Input.GetKey(hPositiveTilKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularspeed);
        }
    }

    public void ModifyPlayerLife(float amount)
    {
        currentLifePoint += amount;
        M_simulador.Instance.PlayerLifeChanged(currentLifePoint / MaxLifePoints);

    }

    public void ModifyPlayerSpeed(float amount)
    {
        currentSpeedVelocity += amount;
        M_simulador.Instance.PlayerSpeedChange(currentSpeedVelocity);

    }
    #endregion
}
