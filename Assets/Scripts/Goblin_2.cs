using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Goblin_2 : MonoBehaviour
{
    public GameObject crystal;
    public GameObject player;
    public NavMeshAgent navMesh;
    public float hp = 100;
    private float maxHP = 100;
    public Image hpImage;
    public Animator animator;

    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("Crystal");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        navMesh.destination = crystal.transform.position;

        Death();

        hpImage.fillAmount = hp / maxHP;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Crystal")
        {
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "Player")
        {
            player.GetComponent<Player>().ChangeHp(20);
            Death();
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public void Death()
    {
        if (hp <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            animator.SetBool("dead",true);
            Invoke("DestroyTheObject", 1.5f);
        }
    }


    public void DestroyTheObject()
    {
        player.GetComponent<Player>().PlayerScore(2);
        Destroy(this.gameObject);

    }
}
