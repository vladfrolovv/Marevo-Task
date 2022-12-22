using System;
using System.Linq;
using UnityEngine;
using TMPro; 

public class DimensionsMenu : MonoBehaviour {
  [SerializeField] private MenuAppear menuAppear; 
  [SerializeField] private CanvasGroup dimensionsMenuCanvasGroup;
  [SerializeField] private GameObject dimensionsMenu;

  [Header("Dimensions")]
  [SerializeField] private TMP_InputField width;
  [SerializeField] private TMP_InputField length;
  [SerializeField] private TMP_InputField depth;

  private void Awake() {
    dimensionsMenuCanvasGroup.alpha = 0;
    dimensionsMenu.SetActive(false);
  }
  
  public void Open() {
    menuAppear.Disappear();
    dimensionsMenu.SetActive(true);
    float dimensionsFrom = dimensionsMenuCanvasGroup.alpha;
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      dimensionsMenuCanvasGroup.alpha = Utilities.Lerp(dimensionsFrom, 1, t);
    }, .2f, () => { }));
  }
  
  public void Close() {
    menuAppear.Appear();
    float dimensionsFrom = dimensionsMenuCanvasGroup.alpha;
    StartCoroutine(Utilities.Animate((float t) => {
      t = Easings.easeOutQuint(t);
      dimensionsMenuCanvasGroup.alpha = Utilities.Lerp(dimensionsFrom, 0, t);
    }, .2f, () => { dimensionsMenu.SetActive(false); }));
  }

  public static Vector3 lastDimensions;
  public static ObjectsManager.Object lastObject;
  public Vector3 GetDimensions() {
    return new Vector3(
      TextIsNumber(width.text) ? int.Parse(width.text) : 100, 
      TextIsNumber(length.text) ? int.Parse(length.text) : 100,
      TextIsNumber(depth.text) ? int.Parse(depth.text) : 100
    );
  }

  private readonly char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };
  private bool TextIsNumber(string text) {
    if (text == String.Empty) 
      return false;

    for (int i = 0; i < text.Length; i++) {
      if (!numbers.Contains(text[i])) {
        return false;
      }
    }
    
    return true;
  }
  
}
