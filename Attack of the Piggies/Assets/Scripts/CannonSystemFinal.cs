using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSystemFinal : SubjectBeingObserved
{
  public Camera mainCam;
  private float angleOfCannon;
  private float MAX_ANGLE = 80f;
  private float MIN_ANGLE = 10f;
  public GameObject pigPrefab;
  private GameObject newPig;
  private float timer;
  private bool timeOver;

    void Start() {
      newPig = Instantiate(pigPrefab);
      timeOver = true;
    }


    void Update() {
      Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.GetComponent<Camera>().transform.position.z);
      Vector3 mouseInWorld = mainCam.GetComponent<Camera>().ScreenToWorldPoint(pointInWorld);
      Vector3 direction = mouseInWorld - transform.position;
      angleOfCannon = Vector3.Angle(direction, Vector3.right);

      if (angleOfCannon <= MAX_ANGLE && angleOfCannon > MIN_ANGLE && direction.y > 0) {
        transform.LookAt(mouseInWorld);
      }

      if (Input.GetMouseButtonDown(0)) {
        timer = 12.5f;
        timeOver = false;
        Notify(this, NotificationType.PiggieFired);
      }

      if(!timeOver) {
        timer -= Time.deltaTime;
      }

      if(!timeOver && timer < 0) {
        newPig = Instantiate(pigPrefab);
        timeOver = true;
      }
    }
}
