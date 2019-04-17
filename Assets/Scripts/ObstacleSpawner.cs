using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    //public GameObject obstacle;

    public GameObject[] obstacles;

    public bool gameOver = false;

    public float minSpawnTime, maxSpawnTime;

    public static ObstacleSpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        StartCoroutine("Spawn");
	}

    //make code wait and execute after few seconds
    IEnumerator Spawn()
    {
        float waitTime = 1f;

        //wait for one second
        yield return new WaitForSeconds(waitTime);

        //check if game over is not true
        while (!gameOver)
        {
            //instantiate new obstacle
            SpawnObstacle();

            //wait time is random range generated from inputted minimum and maximum spawn time
            waitTime = Random.Range(minSpawnTime, maxSpawnTime);

            //create new instance of waitForSeconds class and pause for random amount of waitTime
            yield return new WaitForSeconds(waitTime);   
        }
    }

    void SpawnObstacle()
    {
        //return a random value 
        int random = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[random], transform.position, Quaternion.identity);
    }
}
