using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public GameObject score;
    Text Scoretext;
    public int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        Scoretext = score.GetComponent<Text>();
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        string currentScore = (scoreCount).ToString();
        Scoretext.text = currentScore;
       
    }
}
