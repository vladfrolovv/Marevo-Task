using UnityEngine;
using TMPro;

public class LoadingAnimation : MonoBehaviour {
  [SerializeField] private TextMeshProUGUI loadingText; 
  private void Awake() {
    AnimateLoadingCircle();
  }

  private float waitTime = .2f;
  private void AnimateLoadingCircle() {
    StartCoroutine(Utilities.WithTimeout(() => {
      loadingText.text = ".";
      StartCoroutine(Utilities.WithTimeout(() => {
        loadingText.text = "..";
        StartCoroutine(Utilities.WithTimeout(() => {
          loadingText.text = "...";
          AnimateLoadingCircle();
        }, waitTime));
      }, waitTime));
    }, waitTime));
  }
}
