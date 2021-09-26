using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCapsule : Collectable {
  private Collider col;


    private void Start() {
      value = 5;
      damage = 10;
      collectableName = "Magic Capsule";
    }


    private void Update() {
      Spin(200f, 0f, 0f);
    }


    private void OnTriggerEnter(Collider other) {
      AddToRepos(NotificationType.MagicCapsuleCollected, gameObject, "Player", other);
    }


    protected override void Spin(float rpmX, float rpmY, float rpmZ) {
      transform.Rotate(rpmX * Time.deltaTime, rpmY * Time.deltaTime, rpmZ * Time.deltaTime);
    }


    protected void AddToRepos(NotificationType notificationType, GameObject gObj, string objTag, Collider other) {
      if (other.tag == objTag) {
        Notify(gObj, notificationType);
        gameObject.SetActive(false);
      }
    }
}
