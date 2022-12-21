using UnityEngine;
using System.Collections.Generic;

public class ObjectsManager : MonoBehaviour {
  public List<Object> AVAILABLE_OBJECTS = new List<Object>();
  public class Object {
    public string title;
    public float size;
    public Sprite preview, texture;
    public Object(string title, Sprite preview, Sprite texture, float size) {
      this.title = title;
      this.preview = preview;
      this.texture = texture;
      this.size = size;
    }
  }

}
