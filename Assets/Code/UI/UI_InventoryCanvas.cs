using Code.Utils;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// * Al mantener pulsado un botón va a mostrar un elemento (el panel central)
/// * Cuando se añada una llave al inventario (M_KeyCollection) aparecerá también 
/// en el panel central en forma de IMAGE
/// </summary>
public class UI_InventoryCanvas : Singleton<UI_InventoryCanvas>
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    RectTransform inventoryPanel;

    [SerializeField]
    Image singleKeyImagePrefab;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    KeyCode inventoryKey = KeyCode.I;

    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKey(inventoryKey))
        {
            inventoryPanel.gameObject.SetActive(true);
        }
        else
        {
            inventoryPanel.gameObject.SetActive(false);
        }
    }

    public void AddNewInventoryItem(InventoryItems itemCollected)
    {
        // Creo una instancia nueva del Prefab y la hago hija del panel automáticamente
        Image newImage = Instantiate(singleKeyImagePrefab, inventoryPanel);

        if(itemCollected == InventoryItems.YellowKey)
        {
            newImage.color = Color.yellow;
        }
        else if(itemCollected == InventoryItems.BlueKey)
        {
            newImage.color = Color.blue;
        }
    }

    #endregion
}
