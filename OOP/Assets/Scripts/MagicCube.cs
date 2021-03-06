using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCube : Collectable {
  private Collider col;


    private void Start() {
        value = 10;
        damage = 20;
        collectableName = "Magic Cube";
    }


    private void Update() {
      Spin(50f, 0f, 90f);
    }


    private void OnTriggerEnter(Collider other) {
      AddToRepos(NotificationType.MagicCubeCollected, gameObject, "Player", other);
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
