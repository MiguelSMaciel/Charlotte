using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    private Mother mom;
    int minhaCena;
    private MudarCena CenaControl;
    public GameObject portal;
    public GameObject cadeado;
    public GameObject cadeado2;

    // Start is called before the first frame update
    void Start()
    {
        minhaCena = PlayerPrefs.GetInt("levelAt");
        portal.SetActive(false);
        mom = GameObject.FindGameObjectWithTag("T1").GetComponent<Mother>();
        CenaControl = GetComponent<MudarCena>();
    }

    // Update is called once per frame
    void Update()
    {
        bool t1 = mom.T1Defeat;
        bool t2 = mom.T2Defeat;
        bool t3 = mom.T3Defeat;
        if (t1 && t2 && t3 == true)
        {
            portal.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("deletou");
        }
        if(PlayerPrefs.GetInt("levelAt") >= 2 && PlayerPrefs.GetInt("levelAt") < 3)
        {
            cadeado.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("levelAt") >= 3)
        {
            cadeado2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("levelAt") < 2)
        {
            cadeado.SetActive(true);
            cadeado2.SetActive(true);
        }
    }

    public void IniciarJogo()
    {
        PlayerPrefs.SetInt("Cena", 1);
        SceneManager.LoadScene(1);
    }

    public void ContinuarJogo()
    {
        int cenaAtual = PlayerPrefs.GetInt("Cena");
        SceneManager.LoadScene(cenaAtual);
    }

    public void ChamarCena(int numCena)
    {
        SceneManager.LoadScene(numCena);
        if (numCena > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", numCena);
        }
    }

    public void Level2()
    {
        if(PlayerPrefs.GetInt("levelAt") >= 2)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void Level3()
    {
        if (PlayerPrefs.GetInt("levelAt") >= 3)
        {
            SceneManager.LoadScene(3);
        }
    }
}