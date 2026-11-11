using Code.Utils;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
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
        Image newImage = Instantiate(singleKeyImagePrefab, inventoryPanel);

        if (itemCollected == InventoryItems.YellowKey)
        {
            newImage.color = Color.yellow;
        }
        else if (itemCollected == InventoryItems.GreenKey)
        {
            newImage.color = Color.green;
        }

    }
    #endregion
}

