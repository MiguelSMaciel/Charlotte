using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int minhaCena;
    private MudarCena CenaControl;
    // Start is called before the first frame update
    void Start()
    {
        minhaCena = PlayerPrefs.GetInt("Cena");
        CenaControl = GetComponent<MudarCena>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            minhaCena++;
            PlayerPrefs.SetInt("Cena", minhaCena);
            CenaControl.ChamarCena(minhaCena);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            CenaControl.ChamarCena(5);
        }

    }
}
