using UnityEngine;

public class MenuAppear : MonoBehaviour {
  [SerializeField] private CanvasGroup menuCanvasGroup;
  [SerializeField] private CanvasGroup loadingCanvasGroup;

  private void Start() {
    menuCanvasGroup.alpha = 0;
    loadingCanvasGroup.alpha = 1;
  }
  
  public void Appear() {
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      menuCanvasGroup.alpha = Utilities.Lerp(0, 1, t);
      loadingCanvasGroup.alpha = Utilities.Lerp(1, 0, t);
    }, .2f, () => { }));
  }
  
}
