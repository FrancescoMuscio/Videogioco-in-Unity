using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject bossDefeatedPanel;
    public string MainMenu;

    
    void Start(){
        isPaused = false;
        gameOverPanel.SetActive(false);
        bossDefeatedPanel.SetActive(false);
    }

    
    void Update() {
        if(Input.GetButtonDown("pause") && gameOverPanel.activeSelf == false && bossDefeatedPanel.activeSelf == false){
            ChangePause();
        }
    }

    public void ChangePause(){
        isPaused = !isPaused;
        if(isPaused){
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }else{
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
    }


    public void QuitToMain(){
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }

    public void GameOver(float delay){
        StartCoroutine(GameOverRoutine(delay));
    }

    private IEnumerator GameOverRoutine(float delay){
        yield return new WaitForSeconds(delay); 
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0f; 
    }


    public void BossDefeated(float delay){
        StartCoroutine(BossDefeatedRoutine(delay));
    }

    private IEnumerator BossDefeatedRoutine(float delay){
        yield return new WaitForSeconds(delay);
        bossDefeatedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
