using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonObject : MonoBehaviour
{
    public Enemy enemyData;


    void Update() {
      if (Input.GetKeyDown(KeyCode.F)) {
        enemyData.health -= 1;
      }

      if (enemyData.health <= 0) {
        Destroy(gameObject);
      }
    }
}
