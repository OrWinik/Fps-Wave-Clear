using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crystal : MonoBehaviour
{
    public int hp = 500;
    public TextMeshProUGUI HpText;
    private float hpRecoveyCooldown = 10;
    public GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = hp.ToString();

        Lose();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "goblin_01_Mecanim(Clone)")
        {
            hp -= 50;
            Debug.Log(collision);
        }

        if (collision.collider.name == "Hobgoblin_002_Mecanim(Clone)")
        {
            hp -= 100;
            Debug.Log(collision);
        }

        if(hp <= 450)
        {
            hpRecoveyCooldown -= Time.deltaTime;
            if(hpRecoveyCooldown <= 0)
            {
                hp += 50;
                hpRecoveyCooldown = 10;
            }
        }
    }

    public void Lose()
    {
        if(hp <= 0)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
