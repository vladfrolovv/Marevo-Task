using UnityEngine;

public class MenuAppear : MonoBehaviour {
  [SerializeField] private CanvasGroup menuCanvasGroup;
  [SerializeField] private CanvasGroup loadingCanvasGroup;

  [SerializeField] private GameObject menuGameObject;
  private void Start() {
    menuCanvasGroup.alpha = 0;
    loadingCanvasGroup.alpha = 1;
  }
  
  public void Appear() {
    // menuGameObject.SetActive(true);
    float menuFrom = menuCanvasGroup.alpha, loadingFrom = loadingCanvasGroup.alpha;
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      menuCanvasGroup.alpha = Utilities.Lerp(menuFrom, 1, t);
      loadingCanvasGroup.alpha = Utilities.Lerp(loadingFrom, 0, t);
    }, .2f, () => { }));
  }
  
  public void Disappear() {
    float menuFrom = menuCanvasGroup.alpha;
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      menuCanvasGroup.alpha = Utilities.Lerp(menuFrom, 0, t);
    }, .2f, () => { /*menuGameObject.SetActive(false);*/ }));
  }
  
}
