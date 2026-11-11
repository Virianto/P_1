using Code.Utils;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// * Al mantener pulsado un botón va a mostrar el panel del Canvas
/// * Cuando se añada una llave al inventario se va a mostrar el panel del Canvas
/// </summary>
public class UI_InventoryCanvas : Singleton<UI_InventoryCanvas>
{
    #region ATTRIBUTES

    [SerializeField]
    RectTransform inventoryPanel;

    [SerializeField]
    KeyCode inventoryKey = KeyCode.I;

    [SerializeField]
    Image keyImagePrefab;

    #endregion





    #region METHODS

    private void Update()
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
        // Creamos una instancia nueva del prefab y la hacemos hija del Panel automáticamente
        Image newImage = Instantiate(keyImagePrefab, inventoryPanel);

        if (itemCollected == InventoryItems.GreenKey)
        {
            newImage.color = Color.green;
        }
        else if (itemCollected == InventoryItems.RedKey)
        {
            newImage.color = Color.red;
        }
    }

    #endregion
}