using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    private Mother mom;
    int minhaCena;
    private MudarCena CenaControl;

    // Start is called before the first frame update
    void Start()
    {
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
           NextLevel();
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
    }

    public void NextLevel()
    {
        minhaCena++;
        CenaControl.ChamarCena(minhaCena);
    }
}