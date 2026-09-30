using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public GameObject _pauseCanvas;
    public Button _returnButton;    
    public GameObject gameOverCanvas;
    public Button retryButton;

    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ActivateCanvas(GameObject canvas, Button selectedButton)
    {
        
        if (canvas.activeInHierarchy)
        {
            _pauseCanvas.SetActive(false);
            
        }
        else
        {
            canvas.SetActive(true);
            selectedButton.Select();
        }
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.ChangeScene(sceneName);
    }
}
