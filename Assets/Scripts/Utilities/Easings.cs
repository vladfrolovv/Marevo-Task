using System;
using UnityEngine;
public class Easings {

  public static float easeInSine(float t) {
    return 1f - Mathf.Cos(t * Mathf.PI / 2f);
  }

  public static float easeOutQuint(float t) {
    return 1f - Mathf.Pow(1f - t, 5f);
  }

  public static float easeOutSine(float t) {
    return Mathf.Sin(t * Mathf.PI / 2f);
  }

  public static float easeOutBack(float t, float c1 = 1.70158f) {
    return 1 + (c1 + 1f) * Mathf.Pow(t - 1f, 3) + c1 * Mathf.Pow(t - 1, 2);
  }

  public static float easeOutCubic(float t) {
    return 1 - Mathf.Pow(1 - t, 3);
  }

  public static float easeOutExpo(float t) {
    return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
  }
  
  public static float easeInOutQuad(float t) {
    return (t < 0.5 ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2);
  }

  public static float easeOutBounce(float t) {
    const float n1 = 7.5625f;
    const float d1 = 2.75f;

    if (t < 1 / d1) {
      return n1 * t * t;
    }
    if (t < 2 / d1) {
      return n1 * (t -= 1.5f / d1) * t + 0.75f;
    }
    if (t < 2.5f / d1) {
      return n1 * (t -= 2.25f / d1) * t + 0.9375f;
    }
    return n1 * (t -= 2.625f / d1) * t + 0.984375f;
  }
  
  public static float easeOutElastic(float t) {
    const double c4 = (float)(2 * Math.PI) / 3;
    return (float)(t == 0 ? 0 : t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Math.Sin((t * 10 - 0.75) * c4) + 1);
  }
  
  public static float easeOutCirc(float t) {
    return Mathf.Sqrt(1 - (float)Math.Pow(t - 1, 2));
  }

  public static float easeInBack(float t) {
    float c1 = 1.70158f;
    float c3 = c1 + 1;
    return c3 * t * t * t - c1 * t * t;
  }

}
