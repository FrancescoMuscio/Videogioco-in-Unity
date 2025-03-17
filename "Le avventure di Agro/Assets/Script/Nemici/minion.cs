using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class minion : nemici{
    public Transform target;
    public Transform position;
    public float chaseRadius;
    public float attackRadius;
    private Rigidbody2D myRigidbody;
    public Animator anim;
    
    
    void Start(){
        currentState = State.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void FixedUpdate(){
        CheckDistance();
    }

    void CheckDistance() {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius){

            if(currentState == State.idle || currentState == State.walk && currentState != State.stagger){    
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, velocita * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(State.walk);
                anim.SetBool("wake", true);
            }
        }else if(Vector3.Distance(target.position, transform.position) > chaseRadius){
            anim.SetBool("wake", false);
        }
    }

    
    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("x", setVector.x);
        anim.SetFloat("y", setVector.y);
    }
    
    private void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0){
                 SetAnimFloat(Vector2.left);
            }


        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                 SetAnimFloat(Vector2.up);
            }else if(direction.y < 0){
                 SetAnimFloat(Vector2.down);
            }
        }
    }
    
    
    private void ChangeState(State newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
