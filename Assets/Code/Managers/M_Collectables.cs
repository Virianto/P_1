
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_Collectables : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]
    
    [SerializeField]
    List<SO_InventoryItemConfig> inventoryItemsList = new();

    [Space(10)]

    [Header("EDITABLE VALUES")]

    [SerializeField]
    float horizontalGenerationLimits;

    #endregion


    #region METHODS

    void Start()
    {
        for (int i= 0; i< inventoryItemsList.Count; i++)
        {
            GenerateNewCollectableItem(inventoryItemsList[i]);
        }
    }


    void GenerateNewCollectableItem(SO_InventoryItemConfig itemConfig)
    {
        Vector3 newPosition = new Vector3(Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits), 0.5f, Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits));
        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).GetComponent<B_CollectableItem>();
        newItem.transform.position = newPosition;

        //Asigno los nuevos datos de configuración al objeto que acabo de crear
        newItem.inventoryItemConfig = itemConfig;
    }


    #endregion
}
