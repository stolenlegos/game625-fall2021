using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
  private float timer;

  private Ghost ghostPrototype;
  private Dragon dragonPrototype;
  private Bear bearPrototype;

  private Spawner[] enemySpawners;

  [SerializeField]
  private List<Transform> spawnLocations = new List<Transform>();
  [SerializeField]
  private List<GameObject> enemyPrefabs = new List<GameObject>();


  private void Start() {
    timer = 0;

    ghostPrototype = new Ghost(20, 20);
    dragonPrototype = new Dragon(200, 100);
    bearPrototype = new Bear(50, 75);

    enemySpawners = new Spawner[] {
      new Spawner(ghostPrototype),
      new Spawner(dragonPrototype),
      new Spawner(bearPrototype)
    };
  }


  private void Update() {
    if (timer <= 0) {
      int randomInt = Random.Range(0, enemySpawners.Length);

      Spawner randomSpawner = enemySpawners[randomInt];
      Enemy randomEnemy = randomSpawner.SpawnEnemy();
      GameObject randomPrefab = enemyPrefabs[randomInt];
      Transform randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];

      randomEnemy.Initialise(randomSpawnLocation, randomPrefab);

      timer = 5;
    }
    else {
      timer -= Time.deltaTime;
    }
  }
}
