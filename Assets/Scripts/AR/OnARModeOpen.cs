using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnARModeOpen : MonoBehaviour {
  [SerializeField] private GameObject parallelepipedPrefab;
  private void CreateParallelepiped() {
    GameObject parallelepiped = Instantiate(parallelepipedPrefab, Vector3.zero, Quaternion.identity);
    parallelepiped.transform.localScale = DimensionsMenu.lastDimensions / 100;
    parallelepiped.transform.localPosition += new Vector3(0, parallelepiped.transform.localPosition.y / 2, 0);
    Debug.Log("Texture link: " + DimensionsMenu.lastObject.textureLink);
  }

  private void Start() {
    CreateParallelepiped();
  }
}
