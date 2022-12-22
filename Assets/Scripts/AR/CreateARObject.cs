using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateARObject : MonoBehaviour
{
  [SerializeField] private GameObject parallelepipedPrefab;

  private GameObject parallelepiped;
  public void CreateParallelepiped(Vector3 onPos) {
    parallelepiped = Instantiate(parallelepipedPrefab, onPos, Quaternion.identity);
    parallelepiped.transform.localScale = DimensionsMenu.lastDimensions / 100;
    parallelepiped.transform.localPosition += new Vector3(0, parallelepiped.transform.localPosition.y / 2, 0);
    StartCoroutine(GetTextureRequest());
  }

  private IEnumerator GetTextureRequest() {
    using UnityWebRequest request = UnityWebRequestTexture.GetTexture(DimensionsMenu.lastObject.previewLink);
    yield return request.SendWebRequest();
    
    if (request.result != UnityWebRequest.Result.Success) {
      Debug.Log(request.responseCode + " " + request.error + " With Link: " + DimensionsMenu.lastObject.previewLink);
    } else {
      Texture previewTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
      parallelepiped.GetComponent<Renderer>().material.mainTexture = previewTexture;
    }
  }
}
