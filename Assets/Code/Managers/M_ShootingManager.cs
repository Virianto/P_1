using System.Collections;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_ShootingManager : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    Transform originOfShoot;

    [SerializeField]
    KeyCode shootingKey = KeyCode.L;


    LineRenderer laserLine;

    bool isShooting = false;
    #endregion


    #region METHODS

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!isShooting)
        {
            CheckFrontView();
        }

        if (Input.GetKeyDown(shootingKey))
        {
            ShootLaser();
        }


    }


    void CheckFrontView()
    {
        Ray searchRay = new Ray(originOfShoot.position, originOfShoot.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(searchRay, out hitInfo))
        {
            B_Enemy enemyHit = hitInfo.collider.GetComponent<B_Enemy>();

            laserLine.positionCount = 2;
            laserLine.SetPosition(0, originOfShoot.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                laserLine.startColor = new Color(0.7647059f, 0.2862746f, 0.302114f, 1f); //rojo
                laserLine.endColor = new Color(0.7647059f, 0.2862746f, 0.302114f, 1f); //rojo
            }
            else
            {
                laserLine.startColor = new Color(0.2897293f, 0.8666667f, 0.1764706f, 1f); //verde
                laserLine.endColor = new Color(0.2897293f, 0.8666667f, 0.1764706f, 1f); //verde
            }
        }
        else
        {
            laserLine.positionCount = 0;
        }
    }
    void ShootLaser()
    {
        isShooting = true;
        StartCoroutine(ShootLaserRoutine());

    }

    IEnumerator ShootLaserRoutine()
    {
        //Dibujar el láser (posición y color)
        //Esperar 1 frame
        //Estrechar el láser
        //Esperar 1 frame
        //Estrechar el láser
        //Esperar 1 frame
        //Estrechar el láser
        //Esperar 1 frame
        //Dejar el láser como estaba
        //Volver a poner el booleano a false

        //PASO 1
        //Recoger el punto de origen
        //Definir una dirección de disparo
        //Almacenar eso en una variable temporal de tipo RAY

        Ray ray = new Ray(originOfShoot.position, originOfShoot.forward);

        //PASO 2
        //Definir una variable de tipo RayCastHit para almacenar la información del tiro

        RaycastHit hitInfo;

        //PASO 3
        //Proyectar el rayo
        //Recoger información y decidir qué hacer si ha impactado en algo

        if (Physics.Raycast(ray, out hitInfo))
        {
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, originOfShoot.position);
            laserLine.SetPosition(1, hitInfo.point);


            B_Enemy enemy = hitInfo.collider.GetComponent<B_Enemy>();
            if (enemy != null)
            {
                laserLine.startColor = new Color(0.8679245f, 0.7363456f, 0.1760413f, 1f); //amarillo
                laserLine.endColor = new Color(0.8679245f, 0.7363456f, 0.1760413f, 1f); //amarillo
                enemy.ModifyEnemyLifePoints(-10);
            }
        }
        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;
        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;
        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;
        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier = 1;
        isShooting = false;
    }
}
#endregion

