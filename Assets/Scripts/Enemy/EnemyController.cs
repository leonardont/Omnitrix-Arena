using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health = 20f;
    public float healthIncrease = 2f;
    public int attack = 1;

    public GameObject EnemyDeath;

    public NavMeshAgent enemy;

    [System.NonSerialized]
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (health < 20)
        {
            health += healthIncrease * Time.deltaTime;
        }

        if (player)
        {
            enemy.SetDestination(player.transform.position);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
            
            GameObject EnemyDeathClone = Instantiate(EnemyDeath, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
            Destroy(EnemyDeathClone, 3);
        }
    }
}
