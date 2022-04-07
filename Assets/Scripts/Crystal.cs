using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crystal : MonoBehaviour
{
    public Player player;
    public int playerHighScore;
    public int hp = 500;
    public TextMeshProUGUI HpText;
    private float hpRecoveyCooldown = 10;
    public GameObject loseMenu;
    public GameObject warningText;
    public float WarningCoolDown = 3f;
    public Animator warningTextAnim;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        HpText.text = hp.ToString();

        Lose();

        WarningCoolDown -= Time.deltaTime;
        if(WarningCoolDown <= 0)
        {
            warningText.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "goblin_01_Mecanim(Clone)")
        {
            TakeDamage(50);
            Debug.Log(collision);
        }

        if (collision.collider.name == "Hobgoblin_002_Mecanim(Clone)")
        {
            TakeDamage(100);
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
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            loseMenu.SetActive(true);
            playerHighScore = player.GetComponent<Player>().score;
            SaveHighScore(playerHighScore);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        WarningCoolDown = 3f;
        Warning();
    }

    public void Warning()
    {
        warningText.SetActive(true);
        warningTextAnim.SetTrigger("CrystalHit");
    }

    public void SaveHighScore(int highScore)
    {
        if (highScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
