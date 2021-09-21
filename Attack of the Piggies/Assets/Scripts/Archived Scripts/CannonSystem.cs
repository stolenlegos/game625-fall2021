using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSystem : MonoBehaviour, Observer
{
  public Camera mainCam;
  private float angleOfCannon;
  private float MAX_ANGLE = 80f;
  private float MIN_ANGLE = 10f;
  public GameObject pigPrefab;

    void Start() {
      foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
        subject.AddObserver(this);
      }
    }


    void Update() {
      Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.GetComponent<Camera>().transform.position.z);
      Vector3 mouseInWorld = mainCam.GetComponent<Camera>().ScreenToWorldPoint(pointInWorld);
      Vector3 direction = mouseInWorld - transform.position;
      angleOfCannon = Vector3.Angle(direction, Vector3.right);

      if (angleOfCannon <= MAX_ANGLE && angleOfCannon > MIN_ANGLE && direction.y > 0) {
        transform.LookAt(mouseInWorld);
      }
    }


    public void OnNotify(object obj, NotificationType notificationType) {
      if (notificationType == NotificationType.PiggieFired) {
        Debug.Log("Notified");
        GameObject newPig = Instantiate(pigPrefab);
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
          subject.AddObserver(this);
        }
      }
    }
}
