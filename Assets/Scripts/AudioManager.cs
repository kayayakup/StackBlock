using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance {
        get {
            return instance;
        }
    }

    [Header("Ses Efektleri - Inspector'dan Atayın:")]

    [Tooltip("Blok spawn olduğunda çalan ses")]
    public AudioClip blockSpawnClip;

    [Tooltip("Blok kesildiğinde çalan ses")]
    public AudioClip blockCutClip;

    [Tooltip("Blok tam yerine oturduğunda (perfect) çalan ses")]
    public AudioClip blockPerfectClip;

    [Tooltip("Oyun kaybedildiğinde çalan ses")]
    public AudioClip loseClip;

    [Tooltip("Yeni rekor kırıldığında çalan ses")]
    public AudioClip newRecordClip;

    [Tooltip("Kamera yukarı çıktıkça çalan ses")]
    public AudioClip cameraUpClip;

    [Tooltip("Oyun başlangıç/loading sesi")]
    public AudioClip gameStartClip;

    [Header("Ses Ayarları:")]

    [Range(0f, 1f)]
    [Tooltip("Genel ses efekti seviyesi")]
    public float sfxVolume = 1.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayBlockSpawn()
    {
        PlayClip(blockSpawnClip);
    }

    public void PlayBlockCut()
    {
        PlayClip(blockCutClip);
    }

    public void PlayBlockPerfect()
    {
        PlayClip(blockPerfectClip);
    }

    public void PlayLose()
    {
        PlayClip(loseClip);
    }

    public void PlayNewRecord()
    {
        PlayClip(newRecordClip);
    }

    public void PlayCameraUp()
    {
        PlayClip(cameraUpClip);
    }

    public void PlayGameStart()
    {
        PlayClip(gameStartClip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip, sfxVolume);
        }
    }

    private void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;
        }
    }
}
