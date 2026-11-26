using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lista de objetos q generar
/// Generación aleatoria de todos los objetos de la lista
/// Inicialización de cada objeto para q tenga los datos actualizados
/// </summary>
public class M_Collectable : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL VALUES")]
    [SerializeField]
    List<SO_InventoryItemConfig> inventoryItemList = new();

    [Header("EDITABLE VALUES")]
    [SerializeField]
    float horizontalGenerationLimits;
    #endregion


    #region METHODS
    void Start()
    {
        // Generar todos los objetos de la lista
        // Recorro la lista de objetos
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            GenerateNewCollectableItem(inventoryItemList[i]);
        }
    }
    void GenerateNewCollectableItem(SO_InventoryItemConfig itemConfig)
    {
        // Genero una posición aleatoria para el nuevo objeto
        Vector3 newPosition = new Vector3(
            Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits),
            1,
            Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits));

        // Creo el objeto en escena y me guardo referencia a su script
        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).GetComponent<B_CollectableItem>();
        
        // Reubico el objeto en la escena
        newItem.transform.position = newPosition;

        // Asigno los nuevos datos de configuración al objeto q acabo de crear
        newItem.inventoryItemConfig = itemConfig;
    }

    #endregion
}
