using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : SubjectBeingObserved {
    protected int value;
    protected int damage;
    protected string collectableName;


    protected abstract void Spin(float rpmX, float rpmY, float rpmZ);


    protected void AddToRepos(NotificationType notificationType, GameObject obj) {
      Notify(obj, notificationType);
    }
}
