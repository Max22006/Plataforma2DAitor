using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;
    public AudioClip soundtrack;
    
    

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

        _audioSource = GetComponent<AudioSource>();
    }

    public void StartBGM ()
    {
        _audioSource.clip = soundtrack;
        _audioSource.Play();
    }
    public void PauseBGM ()
    {
        _audioSource.Pause();
    }
   
}
