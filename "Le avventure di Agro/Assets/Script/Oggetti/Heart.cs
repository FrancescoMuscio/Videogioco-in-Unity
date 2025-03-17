using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup, Trigger{
    public FloatValue playerHealth;
    public float amountToIncrease;
    public FloatValue heartContainers;
   


    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger && playerHealth.RuntimeValue < 6){
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.RuntimeValue > heartContainers.RuntimeValue *2f) {
                playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2f;
            }   

            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}



