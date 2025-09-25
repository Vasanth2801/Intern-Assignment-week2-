using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private AudioClip shootingClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundClip != null)
        {
            backgroundMusicSource.clip = backgroundClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    public void PlayShootingSound()
    {
        if (sfxSource != null && shootingClip != null)
        {
            sfxSource.PlayOneShot(shootingClip);
        }
    }
}
