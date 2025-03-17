using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{

    public Transform target;
    public float smoot;
    public Vector2 maxP;
    public Vector2 minP;
    
    void LateUpdate(){
        if(transform.position != target.position){
            Vector3 targetP = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetP.x = Mathf.Clamp(targetP.x, minP.x, maxP.x);
            targetP.y = Mathf.Clamp(targetP.y, minP.y, maxP.y);

            transform.position = Vector3.Lerp(transform.position, targetP, smoot);
        }
    }
}
