using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  private Camera mainCam;
  private Vector3 start;
  private Vector3 des;
  private float fraction;
  private bool zoomIn;
  private float timer;
  private bool timerEnd;

    void Start() {
      mainCam = GetComponent<Camera>();

      start = new Vector3(6.4f, 17.6f, -51f);
      des = new Vector3(10.8f, 16f, -51f);
      fraction = 0;

      zoomIn = false;
      timerEnd = true;
    }


    void Update() {
      if(Input.GetMouseButtonDown(0)) {
        zoomIn = true;
        timer = 7f;
        fraction = 0f;
        timerEnd = false;
      }

      if(zoomIn) {
        fraction += Time.deltaTime / 2.2f;
        transform.position = Vector3.Lerp(start, des, Mathf.SmoothStep(0, 1, fraction));
        mainCam.fieldOfView = Mathf.Lerp(48, 29, Mathf.SmoothStep(0, 1, fraction));
        timer -= Time.deltaTime;
      }

      if(timer <= 0) {
        zoomIn = false;
        timerEnd = true;
        fraction = 0;
        timer = 7f;
      }

      if(timerEnd) {
        fraction += Time.deltaTime / 5f;
        transform.position = Vector3.Lerp(des, start, Mathf.SmoothStep(0, 1, fraction));
        mainCam.fieldOfView = Mathf.Lerp(29, 48, Mathf.SmoothStep(0, 1, fraction));
      }

      Debug.Log(fraction);
    }
}
