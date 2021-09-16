using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, Observer
{
  public void OnNotify(object obj, NotificationType notificationType) {
    if (notificationType == NotificationType.GreenCubeCollected) {
      Debug.Log("Congrats Grad! You Unlocked an achievement");
    }
  }

  void Start() {
    foreach(SubjectBeingObserved observable in FindObjectOfType<SubjectBeingObserved>()) {
      observable.AddObserver(this);
    }
  }
}
