using UnityEngine;
using UnityEngine.UI;

public class CanvasScaler : MonoBehaviour {
  [SerializeField] private UnityEngine.UI.CanvasScaler canvas;
  private void Awake() {
    canvas.scaleFactor = CanvasScale();
  }

  public static float CanvasScale() {
    return Screen.dpi / 160;
  }
}
