using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public GameObject spawnInimigo;

    public GameObject Inimigo1;
    public int onda = 1;
    public float tempo;

    public float vidaT1;
    bool ART1;
    private Movement player;

    public float timeT1;
    public bool T1Defeat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        ART1 = false;
        T1Defeat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (T1Defeat == false)
        {
            if (ART1 == true)
            {
                if (vidaT1 > 0)
                {
                    if (onda < 10)
                    {
                        tempo++;
                        if (tempo > 300)
                        {
                            tempo = 0;
                            int numero = onda * 5;
                            for (int i = 0; i < numero; i++)
                            {
                                Instantiate(Inimigo1, spawnInimigo.transform.position, Quaternion.identity);
                            }
                            onda++;

                        }
                    }
                }
            }
        }
    }
    
    
    public void EntrouNaAreaT1(bool entrou)
    {
        if (entrou == true)
        {
            ART1 = true;
            timeT1 += Time.deltaTime;
            if(timeT1 >= 10f)
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
}
