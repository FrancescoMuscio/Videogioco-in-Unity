using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreValue = 0;
    private Text score;

    void Start(){
        score = GetComponent<Text>();
    }
    
     void Update(){
       score.text = "Score: " + scoreValue;
    }
}
