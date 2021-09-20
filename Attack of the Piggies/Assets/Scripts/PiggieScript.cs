using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggieScript : SubjectBeingObserved
{
  private Camera mainCam;
  private Rigidbody2D rb2d;
  private Transform cannonSprite;
  private CircleCollider2D col;
  private bool notDone;
  private float timer;

    void Start()
    {
      mainCam = GameObject.Find("Camera").GetComponent<Camera>();

      cannonSprite = GameObject.Find("CannonSprite").GetComponent<Transform>();
      transform.SetParent(cannonSprite, true);
      transform.localPosition = new Vector3 (1.467542f, 0.4665815f, 0);

      col = GetComponent<CircleCollider2D>();
      col.enabled = false;

      rb2d = GetComponent<Rigidbody2D>();
      rb2d.gravityScale = 0;

      notDone = true;
      timer = 10;
    }


    void Update()
    {
      Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.GetComponent<Camera>().transform.position.z);
      Vector3 mouseInWorld = mainCam.GetComponent<Camera>().ScreenToWorldPoint(pointInWorld);

      if(Input.GetMouseButtonDown(0)) {
        Notify(this, NotificationType.PiggieFired);
      }

      if(Input.GetMouseButtonDown(0) && notDone) {
        rb2d.gravityScale = 1;
        transform.parent = null;
        col.enabled = true;

        Vector3 direction = mouseInWorld - transform.position;
        Vector2 directionAndMagnitudeOfForce = new Vector2(direction.x, direction.y);
        rb2d.AddForce(directionAndMagnitudeOfForce * 75f);

        Debug.Log("Fired");
        notDone= false;
      }

      if(!notDone) {
        timer -= Time.deltaTime;
        Debug.Log(timer);
      }

      if(timer < 0) {
        gameObject.SetActive(false);
      }
    }
}
