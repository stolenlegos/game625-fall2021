using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanks : Unit {
  private State state;
  private bool enemiesInBase;


    private void Start() {
      enemiesInBase = false;
      this.damagePower = getDamagePower();
      this.health = getHealth();
      state = State.attack;
    }


    private void Update(){
      if (this.health <= 0) {
        die();
      }

      switch(state) {
        case State.attack:
          attack();
          break;
        case State.defend:
          defend();
          break;
        case State.repair:
          repair();
          break;
        default:
          break;
      }
    }


    public override void attack(){
      Debug.Log("Drive towards and attack enemy base.");

      if(this.health < 100){
        state = State.repair;
      }

      if(!enemiesInBase) {
        state = State.attack;
      }
    }


    public override void defend() {
      Debug.Log("Drive back to home base and attack enemies.");

      if(this.health < 100){
        state = State.repair;
      }

      if(!enemiesInBase) {
        state = State.attack;
      }
    }


    public override void repair() {
      Debug.Log("Drive back to home base.");

      if(enemiesInBase){
        state = State.defend;
      }

      if(!enemiesInBase) {
        state = State.attack;
      }
    }


    public override void die(){
      Debug.Log("Cool explosion animation with lots of flames and a person walking away from the explosion without looking at it.");
    }
  }
