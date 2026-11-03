using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Crear instancias prefab agente/s
/// agentes con variable vida
/// al morir, notificar manager, y emitir particulas y sonido
/// manager crea nuevo agente al desaparecer uno
/// </summary>
public class M_3GameManager : MonoBehaviour
{
    #region ATTRIBUTES
    
    [SerializeField]
    GameObject humanoidPrefab;

    [SerializeField]
    KeyCode spawnKey = KeyCode.G;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    List<B_Agent> agentList = new();
    B_Agent newAgent;

    #endregion

    #region METHODS

    private void Awake()
    {
        //newAgent = GetComponent<B_Agent>();
        newAgent = GameObject.FindGameObjectWithTag("agent").GetComponent<B_Agent>();
        //StartCoroutine(newAgent.HurtAgent(newAgent));
    }

    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            float rangoX = Random.Range(-horizontalXRange, horizontalXRange);
            float rangoZ = Random.Range(-horizontalZRange, horizontalZRange);

            Vector3 newRandomPosition = new Vector3(rangoX, 2.5f, rangoZ);

            B_Agent newHuman = Instantiate(humanoidPrefab).GetComponent<B_Agent>();

            agentList.Add(newHuman);
            newHuman.InitializeHuman(this, newRandomPosition); //Se puede hacer con transform

            newAgent = newHuman;
            //StartCoroutine(newHuman.HurtAgent(newHuman));
        } 
        //else
        //    StartCoroutine(newAgent.HurtAgent(newAgent));
    }

    //IEnumerator HurtPlayer(B_CharacterController player)
    //{
    //    //Dañar al jugador
    //    player.TakeDamage(trapDamage);

    //    Debug.Log("Dañar al jugador antes de la espera");
    //    Debug.Log($"Se llama {player.name}");

    //    yield return new WaitForSeconds(trapFrequencyDamage);

    //    //Comprobar si el jugador sigue estando dentro
    //    if (playerIsInsideArea)
    //    {
    //        //Volver a llamar a esta subrutina
    //        StartCoroutine(HurtPlayer(player));
    //    }

    //    Debug.Log("Ya ha pasado la esperas, hacer otra cosa");
    //    Debug.Log($"Sigue llamandose {player.name}");
    //}

    #endregion
}
