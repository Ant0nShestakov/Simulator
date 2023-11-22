using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource;
    private bool _isPlaying;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!_isPlaying)
        {
            _audioSource.PlayOneShot(_audioClips[0]);
            _audioSource.PlayOneShot(_audioClips[1]);
            _isPlaying = true;
        }    
    }

    public void Stop()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClips[2]);
        _isPlaying = false;
    }
}
