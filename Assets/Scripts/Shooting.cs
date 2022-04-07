using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Ray ray;
    public int bulletsInMagazine = 30;
    public TextMeshProUGUI ammoInMagText;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect;
    public bool canShoot = true;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && bulletsInMagazine < 30)
        {
            canShoot = false;
            anim.SetTrigger("Reload");
            FindObjectOfType<AudioManager>().Play("MagIn");
            Invoke("ReloadSound", 1.5f);
            Invoke("Reload", 2);
        }

        if (Input.GetMouseButtonDown(0) && canShoot == true && bulletsInMagazine > 0 && pauseMenu.activeInHierarchy == false && optionsMenu.activeInHierarchy == false)
        {
            MuzzleFlash.Play();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                if(hit.transform.tag == "Enemy")
                {
                    if (hit.transform.name == "goblin_01_Mecanim(Clone)")
                    {
                        Goblin_1 goblin_1 = hit.transform.GetComponent<Goblin_1>();
                        goblin_1.GetComponent<Goblin_1>().TakeDamage(25);
                    }
                    else if (hit.transform.name == "Hobgoblin_002_Mecanim(Clone)")
                    {
                        Goblin_2 goblin_2 = hit.transform.GetComponent<Goblin_2>();
                        goblin_2.GetComponent<Goblin_2>().TakeDamage(25);
                    }
                    else if (hit.transform.name == "wolf_02_Mecanim(Clone)")
                    {
                        Wolf wolf = hit.transform.GetComponent<Wolf>();
                        wolf.GetComponent<Wolf>().TakeDamage(25);
                    }
                    else
                        return;
                }
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            FindObjectOfType<AudioManager>().Play("Shoot");
            bulletsInMagazine--;
        }

        ammoInMagText.text = bulletsInMagazine.ToString();
       
    }

    public void Reload()
    {
        bulletsInMagazine = 30;
        canShoot = true;
    }

    public void ReloadSound()
    {
        FindObjectOfType<AudioManager>().Play("MagOut");
    }

}
