using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRepository : MonoBehaviour, Observer {
  private List<GameObject> _collectables = new List<GameObject>();
  public Text inventoryText;
  private Transform playerPosition;


    void Start() {
      foreach(SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
        subject.AddObserver(this);
      }

      playerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }


    void Update() {
      inventoryText.text = ListToText(_collectables);

      if (Input.GetKeyDown(KeyCode.G)) {
        DropItem();
      }
    }


    public void OnNotify(GameObject obj, NotificationType notificationType) {
      if (notificationType == NotificationType.MagicCubeCollected || notificationType == NotificationType.MagicCapsuleCollected) {
        _collectables.Add(obj);
        obj.transform.SetParent(gameObject.transform);
      }
    }


    private void DropItem() {
      GameObject lastItem = _collectables[_collectables.Count - 1];

      lastItem.transform.SetParent(null);
      lastItem.transform.position = playerPosition.position + new Vector3 (1f, 0f, 1f);
      lastItem.SetActive(true);
      _collectables.RemoveAt(_collectables.Count - 1);
    }


    public string ListToText(List<GameObject> list) {
      string result = "";
      foreach(var listMember in list) {
        result += listMember.name + "\n";
      }
      return result;
    }
}
