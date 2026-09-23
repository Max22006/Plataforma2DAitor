using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _coins;

    private bool _isPaused = false;
   
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
    public void AddCoins()
    {
        _coins += 1;
    }
    public void Pause()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 1;
        }
        else
        {
            _isPaused = true;
            Time.timeScale = 0;
        }
    }
    public bool IsPaused()
    {
        return _isPaused;
    }
}
