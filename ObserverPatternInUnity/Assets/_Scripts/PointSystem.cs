using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour, Observer
{
  private int points;

    public void OnNotify(object obj, NotificationType notificationType) {
        Debug.Log("Notified");
      if (notificationType == NotificationType.GreenCubeCollected) {
        points += 1;
        Debug.Log("You got 1 point. cool.");
      }

      if (notificationType == NotificationType.RedCubeCollected) {
        points += 2;
        Debug.Log("You got 2 points. nice.");
      }

      if (notificationType == NotificationType.YellowCubeCollected) {
        points += 3;
        Debug.Log("You got 3 points. wow.");
      }
    }

    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }
}
