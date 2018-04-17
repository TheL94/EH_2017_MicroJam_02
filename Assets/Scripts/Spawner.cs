using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnPoint;
    public Collider ExitPoint;

    public float SpawnTime;
    float time;

    int Points;

    public List<Obstacle> Obstacles = new List<Obstacle>();

    public float ObstacleSpeed;

    private void Start()
    {
        time = SpawnTime;
        UIManager.I.SetPoints(0);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= SpawnTime)
        {
            time = 0;
            ShootObstacle();
        }
    }

    public void AddPoints()
    {
        Points++;
        UIManager.I.SetPoints(Points);
    }

    void ShootObstacle()
    {
        float obstacleSpeed = ObstacleSpeed;

        if(Points > 10)
            obstacleSpeed += Points / 10f;

        Instantiate(Obstacles[Random.Range(0, Obstacles.Count)], SpawnPoint.transform.position, SpawnPoint.transform.localRotation, null).Init(obstacleSpeed, this);
    }
}
