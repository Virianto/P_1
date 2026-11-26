using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Referenfcia a todas las variables del panel de datos
/// Capacidad para enterarse de cuándo se ha recolectado un objeto
/// Capacidad para modificar el panel con los datos del objeto
/// </summary>
public class UI_CollectionCanvas : Singleton<UI_CollectionCanvas>
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
    /// Modifica uno de los elementos de UI referenciados
    /// </summary>
    /// <param name="itemData">Info actualizada para mostrar</param>
    public void ModifySingleItemPanel(D_SingleInventoryItem itemData)
    {
        itemImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        itemValueText.text = string.Format("{0} €", itemData.itemValue);
    }

    #endregion
}
