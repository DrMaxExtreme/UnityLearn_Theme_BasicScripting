using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private TargetVolumeSetter _volumeSetter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("On");

            _reached?.Invoke();

            _volumeSetter.VolumeChanger(true);

            //if (_volumeChange != null) StopCoroutine(_volumeChange);

            //_volumeChange = StartCoroutine(_volumeSetter.VolumeChange(targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("Off");

            _reached?.Invoke();

            _volumeSetter.VolumeChanger(false);

            //if (_volumeChange != null) StopCoroutine(_volumeChange);

            //_volumeChange = StartCoroutine(_volumeSetter.VolumeChange(targetVolume));
        }
    }
}
