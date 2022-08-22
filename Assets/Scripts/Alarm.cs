using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private float _speedVolumeUp;
    private Coroutine _volumeChange;
    private AudioSource _audioSourceComponent;

    private void Start()
    {
        _audioSourceComponent = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("On");

            if (_volumeChange != null) StopCoroutine(_volumeChange);

            _volumeChange = StartCoroutine(VolumeChange(1));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("Off");

            if (_volumeChange != null) StopCoroutine(_volumeChange);

            _volumeChange = StartCoroutine(VolumeChange(0));
        }
    }

    private IEnumerator VolumeChange(float targetVolume)
    {
        while (GetComponent<AudioSource>().volume != targetVolume)
        {
            _audioSourceComponent.volume = Mathf.MoveTowards(_audioSourceComponent.volume, targetVolume, _speedVolumeUp);

            yield return null;
        }
    }
}
