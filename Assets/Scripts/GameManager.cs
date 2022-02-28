using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wolf;
    public GameObject goblin_1;
    public GameObject goblin_2;
    public Transform[] spawnPoints;
    public Transform randomSpawnPointWolf;
    public Transform randomSpawnPointGoblin_01;
    public Transform randomSpawnPointGoblin_02;
    public float spawnTimer = 2f;
    [SerializeField]private int amoutOfSpawns = 0;
    public float lvlTimer = 15;
    public int lvlCounter = 1;
    public TextMeshProUGUI WaveNumber;

    public TextMeshProUGUI nextwave;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (amoutOfSpawns < lvlCounter && spawnTimer <= 0)
        {
            Spawn();
            amoutOfSpawns++;
            spawnTimer = 2;
        }
      
        lvlTimer -= Time.deltaTime;
        if(lvlTimer <= 0)
        {
            lvlCounter++;
            amoutOfSpawns = 0;
            lvlTimer = 30;
        }



        WaveNumber.text = lvlCounter.ToString();


    }

    void Spawn()
    {
        randomSpawnPointWolf = spawnPoints[Random.Range(0, spawnPoints.Length)];
        randomSpawnPointGoblin_01 = spawnPoints[Random.Range(0, spawnPoints.Length)];
        randomSpawnPointGoblin_02 = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(wolf, randomSpawnPointWolf.transform.position, wolf.transform.rotation);
        Instantiate(goblin_1,randomSpawnPointGoblin_01.transform.position, wolf.transform.rotation);
        Instantiate(goblin_2, randomSpawnPointGoblin_02.transform.position, wolf.transform.rotation);
 
    }

    void NextWaveCoolDown()
    {
        nextwave.text = lvlCounter.ToString();
    }
}
