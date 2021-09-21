using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystemScript : MonoBehaviour, Observer
{
  public int points;
  private bool pointsReset;
  private float timer;
  private bool timerStop;
  private Text scoreText;


    void Start() {
      foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
        subject.AddObserver(this);
      }

      pointsReset = false;
      timer = 0.1f;
      timerStop = false;

      scoreText = GetComponent<Text>();
    }

    void Update() {
      timer -= Time.deltaTime;

      if(!pointsReset && timer < 0 && !timerStop) {
        points = 0;
        timerStop = true;
      }
      scoreText.text = "Score: " + points.ToString();
    }


    public void OnNotify(object obj, NotificationType notificationType) {
      if (notificationType == NotificationType.PiggyPoints) {
        points += 10;
      }

      if (notificationType == NotificationType.GrassPoints) {
        points += 50;
      }

      if (notificationType == NotificationType.Explosion) {
        points += 5000;
      }
    }
}
