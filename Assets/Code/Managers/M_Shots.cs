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

    #endregion
    #region METHODS

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shotKey))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Ray ray = new Ray(shotOrigin.position, shotOrigin.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray,out hitInfo))
        {
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, shotOrigin.position);
            laserLine.SetPosition(1, hitInfo.point);
        }
    }
    #endregion
}

