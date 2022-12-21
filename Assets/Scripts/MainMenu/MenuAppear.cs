using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class MenuAppear : MonoBehaviour {
  [SerializeField] private CanvasGroup canvasGroup;

  public void Appear() {
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      canvasGroup.alpha = Utilities.Lerp(0, 1, t);
    }, .2f, () => { }));
  }
  
}
