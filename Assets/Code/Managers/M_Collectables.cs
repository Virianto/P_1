using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lista de objetos que generar
/// Generación aleatoria de todos los objetos de la lista
/// Inicialización de cada objeto para que tenga los datos actualizados
/// </summary>
public class M_Collectables : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    List<SO_InventoryItemConfig> invetoryItemsList = new();

    [Header("EDITABLE VALUES")]

    [SerializeField]
    float horizontalGenerationLimits;

    #endregion

    #region METHODS

    private void Start()
    {
        //Recorro la lista de objetos:
        for (int i = 0; i < invetoryItemsList.Count; i++)
        {
            GenerateNewCollectableItem(invetoryItemsList[i]);
        }
    }

    void GenerateNewCollectableItem(SO_InventoryItemConfig itemConfig)
    {
        float random = Random.Range(-horizontalGenerationLimits, horizontalGenerationLimits);

        //Genero una posición aleatora para el nuevo objeto
        Vector3 newPos = new Vector3(random, 1, random);

        B_CollectableItem newItem = Instantiate(itemConfig.configData.itemPrefab).GetComponent<B_CollectableItem>();

        //Reubico el objeto en la escena
        newItem.transform.position = newPos;

        //Asigno los nuevos datos de configuración al objeto que acabo de crear
        newItem.inventoryItemConfig = itemConfig;

    }

    #endregion
}
