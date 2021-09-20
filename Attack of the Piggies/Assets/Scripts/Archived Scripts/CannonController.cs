using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
  public Camera mainCam;
  public Rigidbody2D piggie;
  private float angleOfCannon;
  private float MAX_ANGLE = 80f;
  private float MIN_ANGLE = 10f;

    void Start() {
      piggie.gravityScale = 0;
    }

    void Update() {
      Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.GetComponent<Camera>().transform.position.z);
      Vector3 mouseInWorld = mainCam.GetComponent<Camera>().ScreenToWorldPoint(pointInWorld);
      Vector3 direction = mouseInWorld - transform.position;
      angleOfCannon = Vector3.Angle(direction, Vector3.right);

      //Debug.Log(direction);
      Debug.Log(angleOfCannon);

      if (angleOfCannon <= MAX_ANGLE && angleOfCannon > MIN_ANGLE && direction.y > 0) {
        transform.LookAt(mouseInWorld);
      }

      if(Input.GetMouseButton(0)) {
        piggie.gravityScale = 1;
        piggie.transform.parent = null;

        Vector3 temp = mouseInWorld - transform.position;
        Vector2 directionAndMagnitudeOfForce = new Vector2(temp.x, temp.y);
        piggie.AddForce(directionAndMagnitudeOfForce * 1.5f);
      }
    }
}
