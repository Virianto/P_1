using Code.Utils;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Al mantener pulsado un botón va a mstrar un elemento
/// Cuando se añada una llave al inventario (M_KeyCollection) aparecerá en el panel central
/// en forma de IMAGE
/// </summary>
public class UI_InventoryCanvas : Singleton<UI_InventoryCanvas>
{

    #region ATTRIBUTES

    [SerializeField]
    RectTransform inventoryPanel;

    [SerializeField]
    KeyCode inventoryKey = KeyCode.I;

    [SerializeField]
    Image singleKeyImagePrefab;

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
        //Creo una instancia nueva del Prefab y la hago hija del panel automáticamente
       Image newImage=  Instantiate(singleKeyImagePrefab, inventoryPanel);
        if (itemCollected == InventoryItems.YellowKey)
        {
            newImage.color = Color.yellow;
        }
        else if (itemCollected == InventoryItems.RedKey) 
        {
            newImage.color = Color.red; 
        }
    }

    #endregion
}
