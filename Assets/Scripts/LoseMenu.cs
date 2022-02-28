using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
    public bool loseMenuOn = false;
    public float coolDown = 5;

    public void Update()
    {
        if(loseMenu.gameObject.active)
        {
            loseMenuOn = true;
        }

        if(loseMenuOn == true)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
