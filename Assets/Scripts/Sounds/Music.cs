using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _musicClips;
    [SerializeField] private AudioSource _audioSource;

    private int _currentSong;
    private void Update()
    {
        if (_audioSource.isPlaying == false)
        {
            ChangeTrack();
        }
    }

    private void ChangeTrack()
    {
        if (_currentSong == _musicClips.Count - 1)
        {
            _currentSong = 0;
        }

        _audioSource.clip = _musicClips[_currentSong];
        _audioSource.Play();
    }
}
