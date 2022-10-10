using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    public float rotateVelocity;

    private HeroCombat heroCombatScript;
    private Mother mom;
    Stats statsScripts;

    float tempoDano;
    bool takeDamage;

    // Start is called before the first frame update
    void Start()
    {
        statsScripts = GetComponent<Stats>();
        mom = GameObject.FindGameObjectWithTag("T1").GetComponent<Mother>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        heroCombatScript = GetComponent<HeroCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        TomouDano();
    }

    void Mover()
    {
        if (heroCombatScript.targetedEnemy != null)
        {
            if (heroCombatScript.targetedEnemy.GetComponent<HeroCombat>() != null)
            {
                if (!heroCombatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCombatScript.targetedEnemy = null;
                }
            }

        }


        //When pressing the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Checking if the raycast shot hits something that uses the navmesh system.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Floor")
                {
                    //MOVEMENT
                    agent.SetDestination(hit.point);
                    heroCombatScript.targetedEnemy = null;
                    agent.stoppingDistance = 0;

                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }

            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "AreaT1" || other.gameObject.layer == 6)
        {
            mom.EntrouNaAreaT1(true);
        }
        if(other.gameObject.tag == "ExitT1" || other.gameObject.layer == 6)
        {
            mom.SaiuDaAreaT1(true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            
        }
    }
    public void TomouDano()
    {
        if (takeDamage == false)
        {
            TemporizadorDano();
        }
    }

    void TemporizadorDano()
    {
        tempoDano += Time.deltaTime;
        if (tempoDano > 0.5f)
        {
            takeDamage = true;
            tempoDano = 0;
        }
    }
}
