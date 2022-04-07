using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMesh;
    public float hp = 50;
    private float maxHP = 50;
    public Animator animator;
    public Image hpImage;
    public Animator anim;
    public Animation dead;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        navMesh.destination = player.transform.position;

        Death();

        hpImage.fillAmount = hp / maxHP;

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            hp -= 25;
        }

        if (collision.collider.tag == "Player")
        {
            anim.SetBool("attack01", true);
            Invoke("DamagePlayer", 1);
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
    }

    public void Death()
    {
        if (hp <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            anim.SetBool("dead" , true);
            Invoke("DestroyTheObject", 1);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public void DestroyTheObject()
    {
        player.GetComponent<Player>().PlayerScore(1);
        Destroy(this.gameObject);
    }

    public void DamagePlayer()
    {
        player.GetComponent<Player>().ChangeHp(35);
    }
}
