using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Referencia a todas las variables del panel datos
/// saber cuando ha recolectado un objeto
/// modificar el panel con datos de objeto
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
    /// Modifica cada uno de los elementos de UI referenciados
    /// </summary>
    /// <param name="itemData">Info actualizada para mostrar</param>
    public void ModifySinglePanel(D_SingleInventoryItem itemData)
    {
        itemImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        itemValueText.text = string.Format($"{itemData.itemValue}€");
    }

    #endregion
}
