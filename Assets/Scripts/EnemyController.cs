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

    private float distancia;
    public float atkCooldown;
    private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        tempo = atkCooldown;
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
        distancia = Vector3.Distance(transform.position, Heroi.transform.position);
        if (distancia <= 4)
        {
            EntrouAreaAtaque();
        }
        else if (distancia > 4)
        {
            SaiuAreaAtaque();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AreaAtkHeroi")
        {
            statsScript.health -= 40;
        }
    }

    public void EntrouAreaAtaque()
    {
        tempo -= Time.deltaTime;
        if(tempo <= 1)
        {
            anim.SetBool("Atk", true);
        }
        else if(tempo < 0)
        {
            tempo = atkCooldown;
            anim.SetBool("Atk", false);
        }
    }
    public void SaiuAreaAtaque()
    {
        anim.SetBool("Atk", false);
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
