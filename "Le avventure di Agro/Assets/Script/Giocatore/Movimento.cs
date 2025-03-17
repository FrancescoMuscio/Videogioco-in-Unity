using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    stagger,
    idle
}

public class Movimento : MonoBehaviour{

    public PlayerState currentState;
    public float velocita;
    private Rigidbody2D rbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public SignalSender playerHeartSignal;
    public GameObject deathEffect;

    
    void Start(){
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger){
            StartCoroutine(AttackCo());
        }else if (currentState == PlayerState.walk || currentState == PlayerState.idle){
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo(){
        animator.SetBool("attacco", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacco", false);
        yield return new WaitForSeconds(.2f);
        currentState = PlayerState.walk;
    }
    
    void UpdateAnimationAndMove(){
        if (change != Vector3.zero){
            MovimentoPG();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("x", change.x);
            animator.SetFloat("y", change.y);
            animator.SetBool("movimento", true);
        }else{
            animator.SetBool("movimento", false);
        }
    }

    void MovimentoPG(){
        rbody.MovePosition(transform.position + change.normalized * velocita * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage){
        currentHealth.RuntimeValue -= damage;
         playerHeartSignal.Raise();
        if(currentHealth.RuntimeValue > 0){
            StartCoroutine(KnockCo(knockTime));
        }else{
            DeathEffect();
            this.gameObject.SetActive(false);
            FindObjectOfType<PauseManager>().GameOver(2f);
        }
    }
    
    private IEnumerator KnockCo(float knockTime){
        if(rbody != null){
            yield return new WaitForSeconds(knockTime);
            rbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rbody.velocity = Vector2.zero;
        }
    } 

    private void DeathEffect(){
        if(deathEffect != null){
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
    
    
    

