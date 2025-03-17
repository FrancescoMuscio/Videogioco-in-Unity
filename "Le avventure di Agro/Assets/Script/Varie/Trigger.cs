using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Trigger
{
   void OnTriggerEnter2D(Collider2D other);
}
