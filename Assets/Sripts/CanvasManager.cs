using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private GameObject _pauseCanvas;
    
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

    public void ActivateCanvas()
    {
        _pauseCanvas.SetActive(true);


    if (_pauseCanvas.activeInHierarchy)
    {
        _pauseCanvas.SetActive(false);
    }
    else
    {
        _pauseCanvas.SetActive(true);
    }
        
    }
}
