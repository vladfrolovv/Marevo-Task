using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OnARModeOpen : MonoBehaviour {
  [SerializeField] private GameObject parallelepipedPrefab;

  private GameObject parallelepiped;
  private void CreateParallelepiped() {
    parallelepiped = Instantiate(parallelepipedPrefab, Vector3.zero, Quaternion.identity);
    parallelepiped.transform.localScale = DimensionsMenu.lastDimensions / 100;
    parallelepiped.transform.localPosition += new Vector3(0, parallelepiped.transform.localPosition.y / 2, 0);
    StartCoroutine(GetTextureRequest());
  }

  private void Start() {
    CreateParallelepiped();
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
