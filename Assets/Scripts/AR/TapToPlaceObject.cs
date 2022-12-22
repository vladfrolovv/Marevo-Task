using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceObject : MonoBehaviour {
  [SerializeField] private CreateARObject createARObject;
  [SerializeField] private ARRaycastManager arRaycastManager;
  private List<ARRaycastHit> hits = new List<ARRaycastHit>();

  private Camera arCamera;
  private GameObject obj;
  private void Start() {
    obj = null;
    arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
  }
  void Update() {
    if (Input.touchCount == 0) 
      return;
    
    if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits)) {
      if (Input.GetTouch(0).phase == TouchPhase.Began && obj == null) {
        RaycastHit hit;
        if (Physics.Raycast(arCamera.ScreenPointToRay(Input.GetTouch(0).position), out hit)) {
          if (hit.collider.gameObject.CompareTag("Spawnable")) {
            obj = hit.collider.gameObject;
          } else {
            PlaceObject(hits[0].pose.position);
          }
        }
      } else if (Input.GetTouch(0).phase == TouchPhase.Moved && obj != null) {
        obj.transform.position = hits[0].pose.position;
      }
    }
  }

  private void PlaceObject(Vector3 onPos) {
    createARObject.CreateParallelepiped(onPos);
  }

}
