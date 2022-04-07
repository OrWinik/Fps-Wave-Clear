using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Goblin_1 : MonoBehaviour
{
    public GameObject crystal;
    public GameObject player;
    public NavMeshAgent navMesh;
    public float hp = 50;
    private float maxHP = 50;
    public Animator animator;
    public Image hpImage;

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
            animator.SetBool("dead", true);
            Invoke("DestroyTheObject", 1.5f);
        }
    }


    public void DestroyTheObject()
    {
        player.GetComponent<Player>().PlayerScore(1);
        Destroy(this.gameObject);
    }
}
