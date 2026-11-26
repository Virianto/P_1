using Code.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// * Referencia a todas la s variables del panel de datos
/// * Capacidad para enterarse de cuando sea recogido un objeto
/// * Capacidad para modificar el panel con losdatos del objeto
/// </summary>
public class UI_CollectionCanvas : Singleton<UI_CollectionCanvas>
{

    #region ATTRIBUTES

    [SerializeField]
    Image itemImage;

    [SerializeField]
    TMP_Text itemNameText;

    [SerializeField]
    TMP_Text itemValueText;
    #endregion



    #region METHODS

    public void ModifySingleItemPanel(D_SingleInventoryItem itemData)
    {

        itemImage.sprite = itemData.itemIcon;
        itemNameText.text = itemData.itemName;
        itemValueText.text = string.Format("{0} €", itemData.itemValue);

    }


    #endregion
}