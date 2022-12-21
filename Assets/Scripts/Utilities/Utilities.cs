using System;
using UnityEngine;
using System.Collections;

public class Utilities {

  public static IEnumerator WithTimeout(Action action, float timeout) {
    yield return new WaitForSeconds(timeout);
    action();
  }
  
  public static IEnumerator Animate(Action<float> update, float duration, Action onEnd = null) {
    update(0);
    yield return null;
    float start = Time.time;
    float t = 0;
    while ((t = (Time.time - start) / duration) <= 1f) {
      update(t);
      yield return null;
    }
    update(1f);
    if (onEnd != null) {
      onEnd();
    }
  }
  
  public static float Lerp(float from, float to, float t) {
    return from + (to - from) * t;
  }

  public static Vector3 Lerp(Vector3 from, Vector3 to, float t) {
    return from + (to - from) * t;      
  }
}
