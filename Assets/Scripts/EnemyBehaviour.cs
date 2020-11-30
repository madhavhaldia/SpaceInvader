using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    float speedbuffer;
    
    public GameObject enemy;
    GameObject enemyInstance;
    public GameObject enemyLocation;
    public GameObject spawnbox;
    // Start is called before the first frame update
    void Start()
    {
        speedbuffer = speed;
        enemyInstance = SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyInstance)
        {
            Movement();
        }
        else
        {
            enemyInstance = SpawnEnemy();
            speed = speedbuffer;
            
        }
        
    }
    float Timer()
    {
        float timer;
        timer = 1 - ((speed -= Time.deltaTime) / speedbuffer);
       // Debug.Log(timer);
        return timer;
    }    
    void Movement()
    {
        if(speed>=0)
        {
            enemyInstance.transform.position = Vector3.Lerp(spawnbox.transform.position, enemyLocation.transform.position, Timer());
        }
        
    }
    GameObject SpawnEnemy()
    {
        return Instantiate<GameObject>(enemy, spawnbox.transform.position, spawnbox.transform.rotation);
    }
}
