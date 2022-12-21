using UnityEngine;

public class SetApplicationFramerate : MonoBehaviour {
  private void Awake() {
    Application.targetFrameRate = Screen.currentResolution.refreshRate;
  }
}
