using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void Update() {
      Destroy(gameObject, 0.1f);
    }
}
