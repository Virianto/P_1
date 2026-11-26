using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Lista de objetos que generar
/// * Generación aleatoria de todos los objetos de la lista
/// * Inicialización de cada objeto para que tenga los datos actualizados
/// </summary>
public class M_Collectables : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    List<SO_InventoryItemConfig> inventoryItemsList = new();

    [SerializeField]
    float horizontalGenerationLimits;

    #endregion



    #region METHODS

    private void Start()
    {
        // Generar todos los objetos de la lista
        // Recorro la lista de objetos
        for (int i = 0; i < inventoryItemsList.Count; i++)
        {

            GenerateNewColllectableItem(inventoryItemsList[i]);

        }

    }

    private void GenerateNewColllectableItem(SO_InventoryItemConfig itemConfig)
    {
        // Genero una posición aleatoria para el nuevo objeto
        Vector3 newPosition = new Vector3(Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits), 1, Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits));

        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).GetComponent<B_CollectableItem>();

        // Reubico el objeto en la escena
        newItem.transform.position = newPosition;

        // Asigno los nuevos datos de configuración al objeto que acabo de crear
        newItem.inventoryItemConfig = itemConfig;
    }

    #endregion

}