using SimpleJSON;
using UnityEngine;
using System.Collections.Generic;

public class ObjectParser : MonoBehaviour {
  public List<ObjectsManager.Object> ParseObjects(string json) {
    List<ObjectsManager.Object> objects = new List<ObjectsManager.Object>();
    var obj = JSON.Parse(json);
    foreach (var item in obj["values"]) {
      var itemObj = JSON.Parse(item.ToString());
      objects.Add(new ObjectsManager.Object(
        TrimString(itemObj[0][0]),
        TrimString(itemObj[0][1]),
        TrimString(itemObj[0][2]),
        TrimString(itemObj[0][3])
      ));
    }
    
    if (objects.Count > 0)
      objects.Remove(objects[0]);
    
    return objects;
  }

  private string TrimString(string str) {
    return str.Substring(0, str.Length);
  }
}
