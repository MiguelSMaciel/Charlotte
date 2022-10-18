using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject spawnT1;
    public GameObject spawnT2;
    public GameObject spawnT3;

    public GameObject Inimigo1;
    public GameObject Inimigo2;
    public GameObject Inimigo3;

    public GameObject vela1;

    public GameObject Boss;
    public GameObject localBoss;

    public int onda = 1;
    public float tempo;

    public int onda2 = 1;
    public float tempo2;

    public int onda3 = 1;
    public float tempo3;

    bool ART1;
    bool ART2;
    bool ART3;
    private Movement player;

    private float timeT1;
    public bool T1Defeat;

    private float timeT2;
    public bool T2Defeat;

    private float timeT3;
    public bool T3Defeat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        ART1 = false;
        T1Defeat = false;
        ART2 = false;
        T2Defeat = false;
        ART3 = false;
        T3Defeat = false;

        vela1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (T1Defeat == false)
        {
            if (ART1 == true)
            {
                if (onda < 100)
                {
                    tempo++;
                    if (tempo > 300)
                    {
                        tempo = 0;
                        int numero = onda * 1;
                        for (int i = 0; i < numero; i++)
                        {
                            Instantiate(Inimigo1, spawnT1.transform.position, Quaternion.identity);
                        }
                        onda++;

                    }
                }
            }
        }
        if (T2Defeat == false)
        {
            if (ART2 == true)
            {

                if (onda2 < 100)
                {
                    tempo2++;
                    if (tempo2 > 300)
                    {
                        tempo2 = 0;
                        int numero = onda2 * 1;
                        for (int i = 0; i < numero; i++)
                        {
                            Instantiate(Inimigo2, spawnT2.transform.position, Quaternion.identity);
                        }
                        onda2++;

                    }
                }

            }
        }
        if (T3Defeat == false)
        {
            if (ART3 == true)
            {

                if (onda3 < 100)
                {
                    tempo3++;
                    if (tempo3 > 300)
                    {
                        tempo3 = 0;
                        int numero = onda3 * 1;
                        for (int i = 0; i < numero; i++)
                        {
                            Instantiate(Inimigo3, spawnT3.transform.position, Quaternion.identity);
                        }
                        onda3++;

                    }
                }

            }
        }
        if (T1Defeat == true)
        {
            vela1.SetActive(true);
        }
        if (T1Defeat == true && T2Defeat == true && T3Defeat == true)
        {
            /*Instantiate(Boss,localBoss.transform.position, Quaternion.identity);*/
            Boss.SetActive(true);
        }       
    }


    public void EntrouNaAreaT1(bool entrou)
    {
        if (entrou == true)
        {
            ART1 = true;
            timeT1 += Time.deltaTime;
            if (timeT1 >= 10f)
            {
                T1Defeat = true;
            }
        }
    }
    public void SaiuDaAreaT1(bool saiu)
    {
        if (saiu == true)
        {
            ART1 = false;
            timeT1 = 0f;
        }
    }
    public void EntrouNaAreaT2(bool entrou)
    {
        if (entrou == true)
        {
            ART2 = true;
            timeT2 += Time.deltaTime;
            if (timeT2 >= 10f)
            {
                T2Defeat = true;
            }
        }
    }
    public void SaiuDaAreaT2(bool saiu)
    {
        if (saiu == true)
        {
            ART2 = false;
            timeT2 = 0f;
        }
    }
    public void EntrouNaAreaT3(bool entrou)
    {
        if (entrou == true)
        {
            ART3 = true;
            timeT3 += Time.deltaTime;
            if (timeT3 >= 10f)
            {
                T3Defeat = true;
            }
        }
    }
    public void SaiuDaAreaT3(bool saiu)
    {
        if (saiu == true)
        {
            ART3 = false;
            timeT3 = 0f;
        }
    }
}


