using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{
    public List<GameObject> enemies; // list of all the enemies
    public float distanceThreshold = 2f; // distance at which enemies will move away from each other
    public float moveSpeed = 2f; // speed at which enemies will move away from each other

    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = i + 1; j < enemies.Count; j++)
            {
                float distance = Vector3.Distance(enemies[i].transform.position, enemies[j].transform.position);
                if (distance < distanceThreshold)
                {
                    Vector3 direction = (enemies[i].transform.position - enemies[j].transform.position).normalized;
                    enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, enemies[i].transform.position + direction, moveSpeed * Time.deltaTime);
                    enemies[j].transform.position = Vector3.MoveTowards(enemies[j].transform.position, enemies[j].transform.position - direction, moveSpeed * Time.deltaTime);
                }
            }
        }
    }
}




