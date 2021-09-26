using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer {
  void OnNotify(GameObject obj, NotificationType notificationType);
}


public enum NotificationType {
  MagicCubeCollected,
  MagicCapsuleCollected
}
