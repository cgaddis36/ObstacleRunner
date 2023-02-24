using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstaclePrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new Vector3(35f, 0f, -1.47f);
    public float intervalTimer = 2.0f;
    public float delayTimer = 1.5f;
    public int obstacleCount = 0;

    void Start()
    {
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
      InvokeRepeating("SpawnObstacle", intervalTimer, delayTimer);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnObstacle() {
        var randomObstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
      if(!playerControllerScript.gameOver) {
        Instantiate(randomObstacle, spawnPosition, randomObstacle.transform.rotation);
      }
    }
}
