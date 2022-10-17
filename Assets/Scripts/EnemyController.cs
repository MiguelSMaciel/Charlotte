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

    private float tempoAnimSpawn=0.7f;

    public GameObject AreaDeAtk;

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
        if(tempoAnimSpawn < 0 && statsScript.health > 0)
        {
            Agente.SetDestination(Heroi.transform.position);
            anim.SetBool("walk", true);
            particleSpawn.SetActive(false);
        }
        else if (statsScript.health <= 0)
        {
            anim.SetBool("Die", true);
            anim.SetBool("walk", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AreaAtkHeroi")
        {
            statsScript.health -= 40;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("Atk", true);
        }
    }

    public void AtivarAtk()
    {
        AreaDeAtk.SetActive(true);
    }

    public void DesativarAtk()
    {
        AreaDeAtk.SetActive(false);
    }
}
