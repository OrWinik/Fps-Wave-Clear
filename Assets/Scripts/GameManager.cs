using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wolf;
    public GameObject goblin_1;
    public GameObject goblin_2;
    public Player player;
    public Transform[] spawnPoints;
    public Transform randomSpawnPointWolf;
    public Transform randomSpawnPointGoblin_01;
    public Transform randomSpawnPointGoblin_02;


    public float spawnTimer = 0;
    public float spawnTimerForLvl = 5;
    public float lvlTimer = 20;
    public int lvlCounter = 1;
    public TextMeshProUGUI WaveNumber;
    public int lvlScore = 10;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        lvlTimer -= Time.deltaTime;
        if(lvlTimer <= 0)
        {
            lvlCounter++;
            player.GetComponent<Player>().PlayerScore(lvlScore);
            lvlScore += 2;
            lvlTimer = 20;
            if(lvlCounter == 1 || lvlCounter == 5 || lvlCounter == 10)
            {
                spawnTimerForLvl = 5;
            }
            else if(lvlCounter == 2 || lvlCounter == 6 || lvlCounter == 11)
            {
                spawnTimerForLvl = 4;
            }
            else if (lvlCounter == 3 || lvlCounter == 7 || lvlCounter == 12)
            {
                spawnTimerForLvl = 3;
            }
            else if (lvlCounter == 4 || lvlCounter == 8 || lvlCounter == 13)
            {
                spawnTimerForLvl = 2;
            }
            else if (lvlCounter == 5 || lvlCounter == 9 || lvlCounter == 14)
            {
                spawnTimerForLvl = 1;
            }
            else if(lvlCounter >= 15)
            {
                spawnTimerForLvl = 2;
            }
        }

        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            if (5 >= lvlCounter && lvlCounter >= 1)
            {
                SpawnGoblin_1();
            }
            else if(10 >= lvlCounter && lvlCounter > 5)
            {
                SpawnGoblin_1();
                SpawnWolf();
            }
            else if (lvlCounter > 10)
            {
                SpawnGoblin_1();
                SpawnWolf();
                SpawnGoblin_2();
            }
            spawnTimer = spawnTimerForLvl;
        }

        WaveNumber.text = lvlCounter.ToString();
    }

    void SpawnWolf()
    {
        randomSpawnPointWolf = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(wolf, randomSpawnPointWolf.transform.position, wolf.transform.rotation);
    }

    void SpawnGoblin_1()
    {
        randomSpawnPointGoblin_01 = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(goblin_1, randomSpawnPointGoblin_01.transform.position, wolf.transform.rotation);
    }


    void SpawnGoblin_2()
    {
        randomSpawnPointGoblin_02 = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(goblin_2, randomSpawnPointGoblin_02.transform.position, wolf.transform.rotation);
    }

}
