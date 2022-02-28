using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Goblin_1 : MonoBehaviour
{
    public GameObject crystal;
    public float speed = 10f;
    public float hp = 100;
    public TextMeshProUGUI hpText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        crystal = GameObject.Find("Crystal");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = crystal.transform.position - transform.position;
        direction.Normalize();
        transform.position += Time.deltaTime * speed * direction;
        transform.LookAt(crystal.transform);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        hpText.text = hp.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Bullet(Clone)")
        {
            hp -= 25;
            
        }

        if (collision.collider.name == "Crystal")
        {
            speed = 0;
            Destroy(this.gameObject);
        }
    }
}
