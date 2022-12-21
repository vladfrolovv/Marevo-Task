using UnityEngine;
using UnityEngine.UI;

public class GridSetup : MonoBehaviour {
  [SerializeField] private GridLayoutGroup gridLayout;

  private const float maxCellWidth = 150, minCellWidth = 130;
  private void Start() {
    GridInit();
  }

  private void GridInit() {
    float screenWidth = Screen.width * .9f / CanvasScaler.CanvasScale();
    gridLayout.spacing = new Vector2(
      Screen.width * .05f / CanvasScaler.CanvasScale(), 
      Screen.width * .05f / CanvasScaler.CanvasScale()
    );
    
    int maxColsAmount = Mathf.FloorToInt(screenWidth / (minCellWidth + gridLayout.spacing.x));
    int minColsAmount = Mathf.FloorToInt(screenWidth / (minCellWidth + gridLayout.spacing.x));
    gridLayout.constraintCount = minColsAmount;
    
    gridLayout.cellSize = new Vector2(
      screenWidth / gridLayout.constraintCount - gridLayout.spacing.x,
      (screenWidth / gridLayout.constraintCount - gridLayout.spacing.x) * 1.25f
    );
  }
  
}
