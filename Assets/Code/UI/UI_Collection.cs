using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// * Referencia a todas las variables del panel de datos
/// * Capacidad para enterarse de cuándo se ha recolectado un objeto
/// * Capacidad para modificar el panel con los datos del objeto
/// </summary>
public class UI_Collection : Singleton<UI_Collection>
{
    #region ATTRIBUTES

    [Header("External References")]

    [SerializeField]
    Image itemImage;

    [SerializeField]
    TMP_Text itemNameText;

    [SerializeField]
    TMP_Text itemValueText;

    #endregion





    #region METHODS

    /// <summary>
    /// Modificar cada uno de los elementos de UI referenciados
    /// </summary>
    /// <param name="itemData"></param>
    public void ModifySingleItemPanel(D_SingleInventoryItem itemData)
    {
        itemImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        itemValueText.text = string.Format("{0} €", itemData.itemValue);
    }

    #endregion
}