using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioStanza : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraM cam;

    void Start(){
        cam = Camera.main.GetComponent<CameraM>();  
    }

   
   private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            cam.minP += cameraChange;
            cam.maxP += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
