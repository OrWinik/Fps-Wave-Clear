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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            bulletsInMagazine = 30;
        }

        if (Input.GetMouseButtonDown(0) && bulletsInMagazine > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                Vector3 hitPos = hit.point;
                GameObject bulletTemp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
                bulletTemp.transform.LookAt(hitPos);

            }
            FindObjectOfType<AudioManager>().play("Shoot");
            bulletsInMagazine--;
        }

        ammoInMagText.text = bulletsInMagazine.ToString();
       
    }

}
