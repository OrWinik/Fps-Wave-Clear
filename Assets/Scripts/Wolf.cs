using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wolf : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;
    public float hp = 50;
    public TextMeshProUGUI hpText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainPlayer");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position += Time.deltaTime * speed * direction;
        transform.LookAt(player.transform);

        if (hp<=0)
        {
            Destroy(this.gameObject);
        }

        hpText.text = hp.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Bullet(Clone)")
        {
            hp -= 25;
        }

        if (collision.collider.name == "MainPlayer")
        {
            Destroy(this.gameObject);
        }
    }
}
