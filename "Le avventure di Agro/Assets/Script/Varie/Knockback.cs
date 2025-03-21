﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public float damage;


    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Nemici") || other.gameObject.CompareTag("Player")){
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null){
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if(other.gameObject.CompareTag("Nemici") && other.isTrigger){
                    hit.GetComponent<nemici>().currentState = State.stagger;
                    other.GetComponent<nemici>().Knock(hit, knockTime, damage);
                }
                
                if(other.gameObject.CompareTag("Player")){
                    if(other.GetComponent<Movimento>().currentState != PlayerState.stagger){
                        hit.GetComponent<Movimento>().currentState = PlayerState.stagger;
                        other.GetComponent<Movimento>().Knock(knockTime, damage);
                    }
                    
                }
                
            }
        }
    }
}
