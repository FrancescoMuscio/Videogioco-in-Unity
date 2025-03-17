using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TentativiDisplay : MonoBehaviour
{
    private Text playCountText;

    
    void Start(){
        playCountText = GetComponent<Text>();
    }
    
    void Update(){
        playCountText.text = "Tentativi: " + Tentativi.PlayCount;
    }
}
