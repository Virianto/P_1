using UnityEngine;

public class C_Translator : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Vector3 movementAxis = Vector3.up;

    [SerializeField]
    [Range(-10, 10)]
    float movementSpeed = 5;

    #endregion

    #region METHODS

    void Update()
    {        
        transform.Translate(movementAxis * movementSpeed * Time.deltaTime);
    }

    #endregion
}
