using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _coins;
    [SerializeField] private int _stars;

    private bool _isPaused = false;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _pauseSFX;

    [SerializeField] private Text coinText;
    [SerializeField] private Text starText;


   
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
    void Start ()
    {
         AudioManager.Instance.StartBGM();
    }
    public void AddCoins()
    {
        _coins += 1;
        coinText.text = _coins.ToString();
    }
    public void AddStars()
    {
        _stars += 1;
        starText.text = _stars.ToString();
    }
    public void Pause()
    {
        if (_isPaused)
        {
            _isPaused = false;
            AudioManager.Instance.StartBGM();
            Time.timeScale = 1;
            
        }
        else
        {
            _isPaused = true;
            AudioManager.Instance.PauseBGM();
            Time.timeScale = 0;
        }
        CanvasManager.Instance.ActivateCanvas(CanvasManager.Instance._pauseCanvas, CanvasManager.Instance._returnButton);
    }
    public bool IsPaused()
    {
        return _isPaused;
    }
}
