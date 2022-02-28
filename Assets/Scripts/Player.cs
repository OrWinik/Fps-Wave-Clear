using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public int hp = 100;
    public TextMeshProUGUI hpText;

    //Losing
    public GameObject LoseMenu;
    

    // Update is called once per frame
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


        hpText.text = hp.ToString();

        if(hp <= 90)
        {
            hpRecoverCooldown -= Time.deltaTime;
            if(hpRecoverCooldown <= 0)
            {
                hp += hpRecovery;
                hpRecoverCooldown = 10;
            }
        }

        Lose();

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "wolf_02_Mecanim(Clone)")
        {
            hp -= 50;
        }

    }

    public void Lose()
    {
        if(hp<=0)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0;

        }
    }

}