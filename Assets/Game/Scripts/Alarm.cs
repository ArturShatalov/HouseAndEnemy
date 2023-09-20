using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Home _home;

    private float _volumeScale;
    private Coroutine _regulateVolume;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _home.Touched += OnTouched;
    }

    private void OnDisable()
    {
        _home.Touched -= OnTouched;
    }

    private void OnTouched (float target)
    {
        if (_regulateVolume != null)
            StopCoroutine(_regulateVolume);

        _regulateVolume = StartCoroutine(RegulateAudio(target));
    }

    private IEnumerator RegulateAudio(float target)
    {
        _volumeScale = _duration * Time.deltaTime;

        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeScale);
            yield return null;
        }
    }
}