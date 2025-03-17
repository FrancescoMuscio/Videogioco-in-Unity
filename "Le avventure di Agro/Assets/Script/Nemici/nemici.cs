using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State{
    idle,
    walk,
    attack,
    stagger
}




public class nemici : MonoBehaviour{

    public float vita;
    public FloatValue maxVita;
    public string nomeNemico;
    public int baseATT;
    public float velocita;
    public State currentState;
    public GameObject deathEffect;
     public bool isBoss = false;



    public void Awake(){
        switch (Data.difficult){
            case Data.difficolta.facile:
                vita += maxVita.initialValue;
                break;
            case Data.difficolta.normale:
                vita += Mathf.RoundToInt(maxVita.initialValue * 1.5f); 
                break;
            case Data.difficolta.difficile:
                vita += maxVita.initialValue * 2; 
                break;
        }
    }   

    private void TakeDamage(float damage){
        vita -= damage;
        if(vita <= 0){
            FindObjectOfType<Score>().scoreValue += 5;
            DeathEffect();
            this.gameObject.SetActive(false);
            if (isBoss){
            FindObjectOfType<PauseManager>().BossDefeated(2f);
            }
        }
    }

    private void DeathEffect(){
        if(deathEffect != null){
         GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

   public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
    StartCoroutine(KnockCo(myRigidbody, knockTime));
    TakeDamage(damage);
   }

   
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = State.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    } 
}
