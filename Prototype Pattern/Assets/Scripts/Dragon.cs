using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy {


  public Dragon(int health, int speed) {
    this.health = health;
    this.speed = speed;
  }


  public override Enemy Clone() {
    return new Dragon(health, speed);
  }


  public override void Initialise(Transform spawnLocation, GameObject enemyPrefab) {
    GameObject newDragon = GameObject.Instantiate(enemyPrefab);
    newDragon.transform.position = spawnLocation.position;
    DragonObject newDragonData = newDragon.GetComponent<DragonObject>();
    newDragonData.enemyData = this;
  }
}
