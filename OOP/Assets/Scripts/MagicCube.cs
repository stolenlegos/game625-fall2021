using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCube : Collectable
{

    void Start() {
        value = 10;
        damage = 20;
    }


    void Update() {
      Spin(10f, 0f, 90f);
    }

    void OnTriggerEnter(Collider other) {
      if (other.tag == "Player") {
        Destroy(gameObject);
      }
    }

    //Implements abstract method
    protected override void Spin(float rpmX, float rpmY, float rpmZ) {
      transform.Rotate(rpmX * Time.deltaTime, rpmY * Time.deltaTime, rpmZ * Time.deltaTime);
    }
}
