using System.Collections;
using UnityEngine;


/// <summary>
/// * Mover de manera constante el objeto asociado hacia delante
/// * Detectar Input de usuario para girar/rotar el objeto
/// * Añadir tecla de teletransporte
/// </summary>
public class B_PlayerPlane : MonoBehaviour
{
    #region ATTRIBUTES

    #endregion

    [Range(10, 100)]
    public float speed = 20;

    [Range(0, 180)]
    public float angularSpeed = 90;

    public float points = 0;

    [SerializeField]
    float maxLifePoints = 100;

    public float currentLifePoints;

    [SerializeField]
    ParticleSystem speedParticlesLeft;

    [SerializeField]
    ParticleSystem speedParticlesRight;

    [SerializeField]
    KeyCode vNegativeTilKey = KeyCode.W;

    [SerializeField]
    KeyCode vPositiveTilKey = KeyCode.S;

    [SerializeField]
    KeyCode hNegativeTilKey = KeyCode.A;

    [SerializeField]
    KeyCode hPositiveTilKey = KeyCode.D;

    #region METHODS

    private void Awake()
    {
        currentLifePoints = maxLifePoints;
    }

    private void Update()
    {
        // Mover de forma constante el objeto hacia delante
        transform.position += transform.forward * Time.deltaTime * speed;

        // Detectar Input de usuario para rotar el objeto y así maniobrar
        if (Input.GetKey(vNegativeTilKey))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * angularSpeed);
        }

        if (Input.GetKey(vPositiveTilKey))
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * angularSpeed);
        }

        if (Input.GetKey(hNegativeTilKey))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
        }

        if (Input.GetKey(hPositiveTilKey))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * angularSpeed);
        }
    }

    public void ModifySpeed(float speed)
    {
        this.speed = this.speed + speed;
        M_FlightSimulator.Instance.PlayerSpeedChanged(this.speed);
        StartCoroutine(SpeedParticles(4));
    }

    IEnumerator SpeedParticles(float duration)
    {
        // Activamos el sistema de partículas
        speedParticlesLeft.Play();
        speedParticlesRight.Play();

        // Obtenemos los módulos de emisión de las partículas
        var emissionLeft = speedParticlesLeft.emission;
        var emissionRight = speedParticlesRight.emission;

        // Detenemos la emisión tras el tiempo deseado
        yield return new WaitForSeconds(duration);

        // Desactivamos el sistema de partículas
        speedParticlesLeft.Stop();
        speedParticlesRight.Stop();
    }

    public void ModifyPoints(float points)
    {
        this.points = this.points + points;
        M_FlightSimulator.Instance.PlayerPointsChanged(this.points);
    }

    public void ModifyLife(float amount)
    {
        currentLifePoints += amount;
        M_FlightSimulator.Instance.PlayerLifeChanged(currentLifePoints / maxLifePoints);
    }

    #endregion
}