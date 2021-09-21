using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggieScriptFinal : MonoBehaviour, Observer
{
  private Vector3 pointInWorld;
  private Vector3 mouseInWorld;
  private Camera mainCam;
  private Transform cannonSprite;
  private Rigidbody2D rb2d;
  private bool notDone;
  private float timer;
  private Collider2D col;

    void Start() {
      foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
        subject.AddObserver(this);
      }

      rb2d = GetComponent<Rigidbody2D>();
      mainCam = GameObject.Find("Camera").GetComponent<Camera>();
      col = GetComponent<CircleCollider2D>();

      cannonSprite = GameObject.Find("CannonSprite").GetComponent<Transform>();
      transform.SetParent(cannonSprite, true);
      transform.localPosition = new Vector3 (1.467542f, 0.4665815f, 0);
      col.enabled = false;

      notDone = true;
      timer = 10;
    }


    void Update(){
      pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.GetComponent<Camera>().transform.position.z);
      mouseInWorld = mainCam.GetComponent<Camera>().ScreenToWorldPoint(pointInWorld);


      if(!notDone) {
        timer -= Time.deltaTime;
      }

      if(timer < 0) {
        Destroy(gameObject);
      }
    }

    public void OnNotify(object obj, NotificationType notificationType) {
      if(notificationType == NotificationType.PiggieFired && notDone) {
        transform.parent = null;
        rb2d.gravityScale = 1;
        col.enabled = true;

        Vector3 direction = mouseInWorld - transform.position;
        Vector2 directionAndMagnitudeOfForce = new Vector2(direction.x, direction.y);
        rb2d.AddForce(directionAndMagnitudeOfForce * 200f);

        notDone= false;
      }
    }
}
