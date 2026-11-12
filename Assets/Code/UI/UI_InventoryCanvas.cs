using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class UI_InventoryCanvas : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EDITABLE VALUES")]
    [SerializeField]
    RectTransform inventoryPanel;

    [SerializeField]
    KeyCode inventoryKey = KeyCode.I;
    #endregion

    #region METHODS
    void Update()
    {
       if (Input.GetKey(inventoryKey))
        {
            inventoryPanel.gameObject.SetActive(false)
        }
       if (Input.GetKeyDown(addKey)
    }
    void AddNewInventoryItem()
    {

        Instantiate(singleKeyImagePrefab, inventoryPanel)
    }
    #endregion
}
