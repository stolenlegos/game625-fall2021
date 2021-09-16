using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCubeObserved : SubjectBeingObserved
{
  private void OnTriggerEnter(Collider other) {
    Notify(this, NotificationType.YellowCubeCollected);
  }
}
