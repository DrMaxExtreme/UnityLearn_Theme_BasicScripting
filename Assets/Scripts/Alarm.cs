using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private Coroutine _volumeChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PhysicsMovement player))
        {
            float targetVolume = 1f;

            Debug.Log("On");

            _reached?.Invoke();

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

            _reached?.Invoke();

            if (_volumeChange != null) StopCoroutine(_volumeChange);

            _volumeChange = StartCoroutine(VolumeChange(targetVolume));
        }
    }
}
