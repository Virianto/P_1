using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class UI_CollectionCanvas : Singleton<UI_CollectionCanvas>
{

    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    TMP_Text itemNameText;

    [SerializeField]
    Image itemIconImage;

    [SerializeField]
    TMP_Text valueNameText;


    #endregion


    #region METHODS

    /// <summary>
    /// Modifica cada uno de los elementos de UI referenciados
    /// </summary>
    /// <param name="itemData">Información actualizada para mostrar</param>
    public void ModifySingleItemPanel(D_SingleInventoryItem itemData)
    {
        itemIconImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        valueNameText.text = string.Format("{0} €", itemData.itemValue);
    }
    #endregion
}
