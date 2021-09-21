using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBirdScript : MonoBehaviour
{
  private bool hit;
  public GameObject explosionPrefab;

    void Start() {
      hit = false;
    }


    void Update() {
      if (hit) {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
      }
    }


    void OnCollisionEnter2D (Collision2D col) {
      if(col.gameObject.tag != "usedPigs") {
        hit = true;
      }
    }
}
