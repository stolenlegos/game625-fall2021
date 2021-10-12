using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy {
  public int health;
  public int speed;


  public abstract Enemy Clone();


  public abstract void Initialise(Transform spawnLocation, GameObject enemyPrefab);
}
