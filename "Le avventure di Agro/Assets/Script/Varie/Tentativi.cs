using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tentativi
{
    private static string playCountKey = "PlayCount";
    
    
    public static int PlayCount{
        get{ 
            return PlayerPrefs.GetInt(playCountKey, 0); 
        } 
    }

    public static void IncrementPlayCount(){
        int newCount = PlayCount + 1;
        PlayerPrefs.SetInt(playCountKey, newCount);
        PlayerPrefs.Save(); 
    }

     public static void ResetPlayCount(){
        int newCount = 0;
        PlayerPrefs.SetInt(playCountKey, newCount);
        PlayerPrefs.Save(); 
    }
}
