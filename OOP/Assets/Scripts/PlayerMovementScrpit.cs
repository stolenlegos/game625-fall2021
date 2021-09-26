using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScrpit : MonoBehaviour {
  private Rigidbody rb;


    private void Start() {
      rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate() {
      if (Input.GetKey(KeyCode.W)) {
        rb.AddForce(Vector3.forward * 1500 * Time.deltaTime);
      } else if (Input.GetKey(KeyCode.S)) {
        rb.AddForce(Vector3.forward * -1500 * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.D)) {
        rb.AddForce(Vector3.right * 1500 * Time.deltaTime);
      } else if (Input.GetKey(KeyCode.A)) {
        rb.AddForce(Vector3.right * -1500 * Time.deltaTime);
      }
    }
}
