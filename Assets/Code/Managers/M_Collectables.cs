using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X Lista de objetos que generar
/// * Generación aleatoria de todos los objetos de la lista
/// * Inicialización de cada objeto para que tenga los datos actualizados
/// </summary>
public class M_Collectables : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    List<SO_InventoryItemConfig> inventoryItemsList = new();

    [Header("EDITABLE VALUES")]

    [SerializeField]
    float horizontalGenerationLimits;


    #endregion

    #region METHODS

    void Start()
    {
        // Recorro la lista de objetos:
        for(int i = 0; i < inventoryItemsList.Count; i++)
        {
            GenerateNewCollectableItem(inventoryItemsList[i]);
        }
    }
    void GenerateNewCollectableItem(SO_InventoryItemConfig itemConfig)
    {
        // Genero una posición aleatoria para el nuevo objeto
        Vector3 newPosition = new Vector3(
            Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits),
            1,
            Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits));
        // Creo el objeto en escena Y me guardo referencia a su script
        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).
                                    GetComponent<B_CollectableItem>();
        // Reubico el objeto en la escena
        newItem.transform.position = newPosition;
        // Asigno los nuevos datos de configuración al objeto que acabo de crear
        newItem.inventoryItemConfig = itemConfig;
    }

    #endregion
}
