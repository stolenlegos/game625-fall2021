using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : SubjectBeingObserved
{
    void OnCollisionEnter2D(Collision2D col) {
      if(col.gameObject.tag == "Player") {
        Notify(this, NotificationType.PiggyPoints);
      }

      if (col.gameObject.tag == "usedPigs") {
        Notify(this, NotificationType.GrassPoints);
      }
    }
}
