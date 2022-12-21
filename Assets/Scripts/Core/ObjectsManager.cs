using UnityEngine;
using System.Collections.Generic;

public class ObjectsManager : MonoBehaviour {
  [SerializeField] private ObjectParser objectParser;
  
  [Header("Objects Instantiation")]
  [SerializeField] private GameObject objectPrefab;
  [SerializeField] private RectTransform parent;
  
  public List<Object> AVAILABLE_OBJECTS = new List<Object>();
  public class Object {
    public readonly string title, previewLink, textureLink;
    private readonly string size;

    public GameObject thisObject;
    public Object(string title, string previewLink, string textureLink, string size) {
      this.title = title;
      this.previewLink = previewLink;
      this.textureLink = textureLink;
      this.size = size;
    }
  }

  public void FillMenu(string json) {
    AVAILABLE_OBJECTS = objectParser.ParseObjects(json);
    for (int i = 0; i < AVAILABLE_OBJECTS.Count; i++) {
      AVAILABLE_OBJECTS[i].thisObject = (GameObject)Instantiate(objectPrefab, Vector3.zero, Quaternion.identity, parent.transform);
      AVAILABLE_OBJECTS[i].thisObject.GetComponent<ObjectBehaviour>().ObjectSetup(AVAILABLE_OBJECTS[i]);
    }
  }

}
