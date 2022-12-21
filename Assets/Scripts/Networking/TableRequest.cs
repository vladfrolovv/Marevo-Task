using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TableRequest : MonoBehaviour {
  private const string googleAPIKey = "AIzaSyCo5tiU7G2EzQXJWBu09l0P5bDKlKawJ8k";
  private const string spreadsheetID = "1Wj75QfY2F8PkNCTMYvOsL-FxYia2mdGvQITVti1xHMk";
  private const string googleSpreadsheetLink = "https://sheets.googleapis.com/v4/spreadsheets/";
  private const string keyPath = "/values/Sheet1?key=";

  [SerializeField] private ObjectsManager objectsManager;
  
  private void Start() {
    StartCoroutine(GetTableJson());
  }
  
  private IEnumerator GetTableJson() {
    string link = (googleSpreadsheetLink + spreadsheetID + keyPath + googleAPIKey);
    using UnityWebRequest request = UnityWebRequest.Get(link);
    yield return request.SendWebRequest();
    if (request.result != UnityWebRequest.Result.Success) {
      // show error || send another request
      Debug.Log("ERROR: " + request.responseCode);
      yield break;
    }

    objectsManager.FillMenu(request.downloadHandler.text);
  }
}
