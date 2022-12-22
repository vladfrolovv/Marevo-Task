using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteraction : MonoBehaviour, IPointerClickHandler {

  public void OnPointerClick(PointerEventData eventData) {
    OpenDimensionsMenu();
  }

  private void OpenDimensionsMenu() {
    if (Camera.main.GetComponent<DimensionsMenu>()) {
      Camera.main.GetComponent<DimensionsMenu>().Open();
      DimensionsMenu.lastObject = GetComponent<ObjectBehaviour>().thisObject;
    }
  }
}
