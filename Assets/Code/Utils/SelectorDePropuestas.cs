using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PropuestaSimple
{
    public string Persona;
    public string Propuesta;
}

public class SelectorDePropuestas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    KeyCode teclaDeSelección = KeyCode.Space;

    public List<PropuestaSimple> listaDePropuestas = new();

    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKeyDown(teclaDeSelección))
        {
            SeleccionarPropuestaAlAzar();
        }
    }

    void SeleccionarPropuestaAlAzar()
    {
        int ganador = (int)UnityEngine.Random.Range(0, listaDePropuestas.Count);

        Debug.LogFormat("Ha ganado la propuesta de {0} : {1}", listaDePropuestas[ganador].Persona, listaDePropuestas[ganador].Propuesta);
    }

    #endregion
}
