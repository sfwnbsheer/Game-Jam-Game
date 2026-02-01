using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Common SFX")]
    public AudioClip jumpSFX;
    public AudioClip walkSFX;
    public AudioClip pushSFX;
    public AudioClip playerDieSFX;
    public AudioClip enemyDieSFX;
    public AudioClip maskCollectSFX;
    public AudioClip buttonClickSFX;
    public AudioClip buttonhoverSFX;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    // Helper methods (clean calls)
    public void PlayJump() => PlaySFX(jumpSFX);
    public void PlayWalk() => PlaySFX(walkSFX);
    public void PlayPush() => PlaySFX(pushSFX);
    public void EnemyDie() => PlaySFX(enemyDieSFX);
    public void PlayerDie() => PlaySFX(enemyDieSFX);
    public void PlayMaskCollect() => PlaySFX(maskCollectSFX);
    public void PlayButton() => PlaySFX(buttonClickSFX);
    public void PlayHover() => PlaySFX(buttonClickSFX);

}