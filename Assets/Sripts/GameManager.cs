using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _coins;
    private bool _isPaused = false;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _pauseSFX;
   
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
            //_audioSource.PlayOneShot(_pauseSFX);
            Time.timeScale = 0;
        }
    }
    public bool IsPaused()
    {
        return _isPaused;
    }
}
