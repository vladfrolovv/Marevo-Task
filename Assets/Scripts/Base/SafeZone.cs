using UnityEngine;

public class SafeZone : MonoBehaviour {
  [SerializeField] private Canvas canvas;
  private ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;
  private Rect currentSafeArea;

  private RectTransform panelSafeArea;

  private void Start() {
    panelSafeArea = GetComponent<RectTransform>();

    currentOrientation = Screen.orientation;
    currentSafeArea = Screen.safeArea;

    ApplySafeArea();
  }

  private void FixedUpdate() {
    if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea) {
      ApplySafeArea();
    }
  }

  private void ApplySafeArea() {
    if (panelSafeArea == null) {
      return;
    }

    Rect safeArea = Screen.safeArea;

    Vector2 anchorMin = safeArea.position;
    Vector2 anchorMax = safeArea.position + safeArea.size;

    anchorMin.x /= canvas.pixelRect.width;
    anchorMin.y /= canvas.pixelRect.height;

    anchorMax.x /= canvas.pixelRect.width;
    anchorMax.y /= canvas.pixelRect.height;

    panelSafeArea.anchorMin = anchorMin;
    panelSafeArea.anchorMax = anchorMax;

    currentOrientation = Screen.orientation;
    currentSafeArea = Screen.safeArea;
  }
}
