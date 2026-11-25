
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Shots : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("Shot Origins")]
    [SerializeField] private List<Transform> shotOrigins = new List<Transform>();

    [Header("Laser")]
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserRange = 1000f;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer;

    private bool isShooting = false;

    #endregion

    #region METHODS

    void Awake()
    {
        if (laserLine == null)
            laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!isShooting)
        {
            CheckFrontView();
        }
    }

    public void ShootLaser()
    {
        if (isShooting || shotOrigins.Count == 0)
            return;

        isShooting = true;

        // Seleccionar un origen aleatorio
        int randomIndex = Random.Range(0, shotOrigins.Count);

        Transform selectedOrigin = shotOrigins[randomIndex];

        StartCoroutine(ShotLaserRoutine(selectedOrigin));
    }

    IEnumerator ShotLaserRoutine(Transform selectedOrigin)
    {
        // Crear el Raycast desde el origen seleccionado
        Ray laser = new Ray(
            selectedOrigin.position,
            selectedOrigin.forward
        );

        RaycastHit hitInfo;

        // Comprobar impacto
        if (Physics.Raycast(laser, out hitInfo, laserRange))
        {
            laserLine.positionCount = 2;

            laserLine.SetPosition(0, selectedOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);

            B_Enemies enemy = hitInfo.collider.GetComponent<B_Enemies>();

            if (enemy != null)
            {
                laserLine.startColor = Color.yellow;
                enemy.ModifyEnemyLifePoints(-10);
            }
        }
        else
        {
            laserLine.positionCount = 2;

            laserLine.SetPosition(0, selectedOrigin.position);
            laserLine.SetPosition(
                1,
                selectedOrigin.position + selectedOrigin.forward * laserRange
            );
        }

        // Estrechar el láser progresivamente
        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;

        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;

        yield return new WaitForEndOfFrame();
        laserLine.widthMultiplier *= 0.5f;

        // Restaurar grosor
        laserLine.widthMultiplier = 1f;

        isShooting = false;
    }

    void CheckFrontView()
    {
        if (shotOrigins.Count == 0)
            return;

        Transform selectedOrigin = shotOrigins[0];

        Ray searchRay = new Ray(
            selectedOrigin.position,
            selectedOrigin.forward
        );

        RaycastHit hitInfo;

        if (Physics.Raycast(searchRay, out hitInfo, laserRange))
        {
            Debug.Log("Objeto detectado: " + hitInfo.collider.name);

            if (hitInfo.collider.CompareTag("Ground"))
            {
                laserLine.positionCount = 2;

                laserLine.SetPosition(0, selectedOrigin.position);
                laserLine.SetPosition(1, hitInfo.point);

                laserLine.startColor = Color.green;
                laserLine.endColor = Color.green;
            }
            else
            {
                laserLine.positionCount = 0;
            }
        }
        else
        {
            laserLine.positionCount = 0;
        }
    }

    #endregion
}
