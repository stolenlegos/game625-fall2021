using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
  public Camera camera;
  public Rigidbody2D piggie;

    void Start() {
      piggie.gravityScale = 0;
    }

    void Update() {
      Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);

      Vector3 mouseInWorld = camera.ScreenToWorldPoint(pointInWorld);

      transform.LookAt(mouseInWorld);

      if(Input.GetMouseButton(0)) {
        piggie.gravityScale = 1;
        piggie.transform.parent = null;

        Vector3 temp = mouseInWorld - transform.position;
        Vector2 directionAndMagnitudeOfForce = new Vector2(temp.x, temp.y);
        piggie.AddForce(directionAndMagnitudeOfForce * 2);
      }
    }
}
