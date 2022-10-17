using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject Heroi;
    private NavMeshAgent Agente;
    Stats statsScript;

    public GameObject particleSpawn;
    public Animator anim;

    private float tempoAnimSpawn=1.5f;

    // Start is called before the first frame update
    void Start()
    {
        statsScript = GetComponent<Stats>();
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
        anim.SetBool("walk", false);
        particleSpawn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        tempoAnimSpawn -= Time.deltaTime;
        if(tempoAnimSpawn < 0)
        {
        Agente.SetDestination(Heroi.transform.position);
            anim.SetBool("walk", true);
            particleSpawn.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AreaAtkHeroi")
        {
            statsScript.health -= 40;
            anim.SetBool("Die", true);
        }
    }
}
