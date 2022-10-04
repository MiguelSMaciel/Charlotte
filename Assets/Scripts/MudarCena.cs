using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}