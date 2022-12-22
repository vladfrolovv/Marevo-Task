using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenARMode : MonoBehaviour {
  [SerializeField] private DimensionsMenu dimensionsMenu;
  
  private const string sceneName = "ARScene";
  public void OpenAR() {
    DimensionsMenu.lastDimensions = dimensionsMenu.GetDimensions();
    SceneManager.LoadSceneAsync(sceneName);
  }
}
