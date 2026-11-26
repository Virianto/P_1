using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Lista de objetos que generar
/// * Generación aleatoria de todos los objetos de la lista
/// * Inicialización de cada objeto para que tenga los datos actializados
/// </summary>
public class M_Collectables : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External References")]

    [SerializeField]
    List<SO_InventoryItemConfig> inventoryItemsList = new();

    [Header("Editable values")]

    [SerializeField]
    float horizontalGenerationLimits;

    #endregion





    #region METHODS

    void Start()
    {
        // Generar todos los objetos de la lista

        // Recorrer la lista de objetos
        for (int i = 0; i < inventoryItemsList.Count; i++)
        {
            GenerateNewCollectableItem(inventoryItemsList[i]);
        }
    }

    void GenerateNewCollectableItem(SO_InventoryItemConfig itemConfig)
    {
        // Generar posición aleatoria para el nuevo objeto
        Vector3 newPosition = new Vector3(Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits), 0.5f, Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits));

        // Crear el objeto en la escena y guardo referencia a su script
        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).GetComponent<B_CollectableItem>();

        // Reubico el objeto en la escena
        newItem.transform.position = newPosition;

        // Asignar los nuevos datos de configuración al objeto que acabo de crear
        newItem.inventoryItemConfig = itemConfig;
    }

    #endregion
}