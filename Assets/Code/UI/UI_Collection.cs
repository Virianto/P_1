using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collection : Singleton<UI_Collection>
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Image itemImage;

    [SerializeField]
    TMP_Text itemNameText;

    [SerializeField]
    TMP_Text itemValueText;

    #endregion

    #region METHODS

    /// <summary>
    /// Modifica cada uno de los elementos de UI referenciados
    /// </summary>
    /// <param name="itemData">Información actualizada para mostrar</param>
    public void ModifySingleItemPanel(D_SingleInventoryItem itemData)
    {
        itemImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        itemValueText.text = string.Format("{0} €", itemData.itemValue);
    }

    #endregion
}
