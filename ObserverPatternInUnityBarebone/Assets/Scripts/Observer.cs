using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer {
  public void OnNotify(object obj, NotificationType notificationType);

}

public enum NotificationType {
  RedCubeCollected,
  GreenCubeCollected
}
