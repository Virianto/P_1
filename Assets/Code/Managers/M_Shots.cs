using System.Collections;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_Shots : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Transform shotOrigin;

    [SerializeField]
    KeyCode shotKey = KeyCode.F;

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

        if (Input.GetKeyDown(shotKey))
        {
            ShootLaser();
        }
    }
    void ShootLaser()
    {
        isShooting = true;
        StartCoroutine(ShotLaserRoutine());
    }

    IEnumerator ShotLaserRoutine()
    {
        // PASO 1
        // Recoger el punto de origen
        // Definir una dirección de disparo
        // Almacenar todo eso en una variable temporal de tipo Ray
        Ray laser = new Ray(shotOrigin.position, shotOrigin.forward);

        // PASO 2
        // Definir una variable de tipo RayCastHit para almacenar la información del tiro
        RaycastHit hitInfo;

        // PASO 3
        // - Proyectar el rayo
        // - Recoger información y decidir qué hacer si ha impactado en algo
        if (Physics.Raycast(laser, out hitInfo))
        {
            // Dibujar una línea entre el punto de origen y el de impacto
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_Enemies enemy = hitInfo.collider.GetComponent<B_Enemies>();

            if (enemy != null)
            {
                laserLine.startColor = Color.yellow;
                enemy.ModifyEnemyLifePoints(-10);
            }
        }

        //Esperar 1 frame
        yield return new WaitForEndOfFrame();

        // Estrechar el laser
        laserLine.widthMultiplier *= 0.5f;

        //Esperar 1 frame
        yield return new WaitForEndOfFrame();

        // Estrechar el laser
        laserLine.widthMultiplier *= 0.5f;

        //Esperar 1 frame
        yield return new WaitForEndOfFrame();

        // Estrechar el laser
        laserLine.widthMultiplier *= 0.5f;

        // Dejar el laser como estaba
        laserLine.widthMultiplier = 1;

        // Volver a poner el booleano a FALSE
        isShooting = false;

    }

    void CheckFrontView()
    {
        Ray searchRay = new Ray(shotOrigin.position, shotOrigin.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(searchRay, out hitInfo))
        {
            B_Enemies enemyHit = hitInfo.collider.GetComponent<B_Enemies>();

            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            if (enemyHit != null)
            {
                laserLine.startColor = Color.red;
            }
            else
            {
                laserLine.startColor = Color.green;
            }
        }
        else
        {
            laserLine.positionCount = 0;
        }

    }

    #endregion
}