using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestioneMenu : MonoBehaviour
{
    public static GestioneMenu instanza;
    public GameObject diff;   
    
    private void Awake(){
        instanza = this;
    }

    public void Uscita(){
        Tentativi.ResetPlayCount();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #else
        Application.Quit(); 
        #endif
    }

    public void SetFacile(bool on) {
        if (on){
            Data.difficult = Data.difficolta.facile;
        }
    }

    public void SetNormale(bool on) {
        if (on){
            Data.difficult = Data.difficolta.normale;
        }
    }

    public void SetDifficile(bool on) {
        if (on){
            Data.difficult = Data.difficolta.difficile;
        }
    }

    public void NuovaPartita(int scena){
        Tentativi.IncrementPlayCount();
        AsyncOperation op = SceneManager.LoadSceneAsync(scena);
        Time.timeScale = 1;
    }
}
