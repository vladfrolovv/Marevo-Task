using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class ObjectBehaviour : MonoBehaviour {
  private ObjectsManager.Object thisObject;

  [Header("Tile")]
  [SerializeField] private TextMeshProUGUI title;
  [SerializeField] private Image cover;
  
  public void ObjectSetup(ObjectsManager.Object obj) {
    thisObject = obj;
    StartCoroutine(GetCoverRequest());
    title.text = thisObject.title;
  }

  private IEnumerator GetCoverRequest() {
    using UnityWebRequest request = UnityWebRequestTexture.GetTexture(thisObject.previewLink);
    yield return request.SendWebRequest();
    
    if (request.result != UnityWebRequest.Result.Success) {
      Debug.Log(request.responseCode + " " + request.error + " With Link: " + thisObject.previewLink);
    } else {
      Texture2D previewTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
      cover.sprite = Sprite.Create(previewTexture, new Rect(0, 0, previewTexture.width, previewTexture.height), Vector2.one * .5f);
      cover.type = Image.Type.Simple;
    }
  }

}
