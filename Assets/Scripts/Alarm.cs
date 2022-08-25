using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private float _speedVolumeUp;
    [SerializeField] private AudioSource _audioSourceComponent;

    private Coroutine _volumeChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PhysicsMovement player))
        {
            float targetVolume = 1f;

            Debug.Log("On");

            if (_volumeChange != null) StopCoroutine(_volumeChange);

            _volumeChange = StartCoroutine(VolumeChange(targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PhysicsMovement player))
        {
            float targetVolume = 0f;

            Debug.Log("Off");

            if (_volumeChange != null) StopCoroutine(_volumeChange);

            _volumeChange = StartCoroutine(VolumeChange(targetVolume));
        }
    }

    private IEnumerator VolumeChange(float targetVolume)
    {
        while (_audioSourceComponent.volume != targetVolume)
        {
            _audioSourceComponent.volume = Mathf.MoveTowards(_audioSourceComponent.volume, targetVolume, _speedVolumeUp);

            yield return null;
        }
    }
}
