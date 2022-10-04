using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject Heroi;
    private NavMeshAgent Agente;
    Stats statsScript;
    // Start is called before the first frame update
    void Start()
    {
        statsScript = GetComponent<Stats>();
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Agente.SetDestination(Heroi.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AreaAtkHeroi")
        {
            statsScript.health -= 20;
        }
    }
}
