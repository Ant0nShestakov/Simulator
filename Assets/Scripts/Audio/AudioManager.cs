using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;

    private void Start() => _audioSource = GetComponent<AudioSource>();

    private void SwitchAndPlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void Play()
    {
        if (_audioClips.Length == 0)
            return;

        if (!_audioSource.isPlaying)
        {
            SwitchAndPlayClip(_audioClips[0]);
            if (_audioClips.Length > 1)
                SwitchAndPlayClip(_audioClips[1]);
        }    
    }

    public void Stop()
    {
        if (_audioClips.Length == 0)
            return;

        if (_audioClips.Length > 2)
            SwitchAndPlayClip(_audioClips[2]);
    }
}
