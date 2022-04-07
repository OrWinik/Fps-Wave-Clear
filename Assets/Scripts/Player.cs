using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float JumpHight = 3f;

    //rigidbody copy
    [SerializeField] private float gravity = -10;
    public Transform groundCheck;
    public float groundDistance = -2f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool touchingGround;

    //Life
    public float hpRecoverCooldown = 10;
    private int hpRecovery = 10;
    public float hp = 100;
    private float maxHP = 100;
    public TextMeshProUGUI hpText;
    public Image HPimage;

    //Losing
    public GameObject LoseMenu;

    //score
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Crystal crystal;

    public void Awake()
    {
        LoseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        crystal = FindObjectOfType<Crystal>();
    }

    void Update()
    {
        touchingGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(touchingGround && velocity.y<0)
        {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            velocity.y = Mathf.Sqrt(JumpHight * gravity * -2f);
        }

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Movement = transform.right * Horizontal + transform.forward * Vertical;

        controller.Move(Movement * Time.deltaTime * playerSpeed);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(hp <= 90)
        {
            hpRecoverCooldown -= Time.deltaTime;
            if(hpRecoverCooldown <= 0)
            {
                hp += hpRecovery;
                hpRecoverCooldown = 10;
                UpdateHP();
            }
        }

        Lose();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<AudioManager>().Play("Walk");
        }
        else if(Horizontal == 0 && Vertical==0)
        {
            FindObjectOfType<AudioManager>().Pause("Walk");
        }

        scoreText.text = score.ToString();
    }

    public void ChangeHp(float DamageTaken)
    {
        hp = hp - DamageTaken;
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        UpdateHP();
    }

    public void UpdateHP()
    {
        HPimage.fillAmount = hp / maxHP;
    }

    public void Lose()
    {
        if(hp<=0)
        {
            LoseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            crystal.GetComponent<Crystal>().SaveHighScore(score);
        }
    }

    public void PlayerScore(int addedScore)
    {
        score += addedScore;
    }

}