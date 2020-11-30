using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    SpaceShipController SpaceShipController;
    GameObject Score;
    scoreManager scoreManager;
   
    // Start is called before the first frame update
    void Start()
    {
        SpaceShipController = GameObject.Find("Player").GetComponent<SpaceShipController>();
        Score = GameObject.Find("EventSystem");
        scoreManager = Score.GetComponent<scoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject)
        {
            if (SpaceShipController.didHit)
            {
                Die();
                SpaceShipController.didHit = false;
            }
        }
        
    }

    void Die()
    {
        scoreManager.scoreCount++;
        Destroy(this.gameObject);
        scoreManager.UpdateText();
    }
}
