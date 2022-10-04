using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class Abilities : MonoBehaviour
{
    [Header("Ability1")]
    public Image abilityImagem1;
    public float cooldown1 = 5;
    private bool isCooldown = false;
    public KeyCode ability1;

    [Header("Ability2")]
    public Image abilityImagem2;
    public float cooldown2 = 11;
    private bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability3")]
    public Image abilityImagem3;
    public float cooldown3 = 11;
    private bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability4")]
    public Image abilityImagem4;
    public float cooldown4 = 11;
    private bool isCooldown4 = false;
    public KeyCode ability4;

    public GameObject Poder1;
    public Transform areaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        abilityImagem1.fillAmount = 0;
        abilityImagem2.fillAmount = 0;
        abilityImagem3.fillAmount = 0;
        abilityImagem4.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImagem1.fillAmount = 1;
            Instantiate(Poder1, areaPlayer.transform.position, Quaternion.identity);
        }
        if (isCooldown)
        {
            abilityImagem1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImagem1.fillAmount <= 0)
            {
                abilityImagem1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImagem2.fillAmount = 1;
        }
        if (isCooldown2)
        {
            abilityImagem2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImagem2.fillAmount <= 0)
            {
                abilityImagem2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImagem3.fillAmount = 1;
        }
        if (isCooldown3)
        {
            abilityImagem3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilityImagem3.fillAmount <= 0)
            {
                abilityImagem3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
    void Ability4()
    {
        if (Input.GetKey(ability4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abilityImagem4.fillAmount = 1;
        }
        if (isCooldown4)
        {
            abilityImagem4.fillAmount -= 1 / cooldown4 * Time.deltaTime;
            if (abilityImagem4.fillAmount <= 0)
            {
                abilityImagem4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
