using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private float _speedVolumeUp;
    private Coroutine _volumeValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("On");

            if (_volumeValue != null) StopCoroutine(_volumeValue);

            _volumeValue = StartCoroutine(VolumeUp());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PhysicsMovement player))
        {
            Debug.Log("Off");

            if (_volumeValue != null) StopCoroutine(_volumeValue);

            _volumeValue = StartCoroutine(VolumeDown());
        }
    }

    private IEnumerator VolumeUp()
    {
        while (GetComponent<AudioSource>().volume < 1)
        {
            GetComponent<AudioSource>().volume = Mathf.MoveTowards(GetComponent<AudioSource>().volume, 1, _speedVolumeUp);

            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        while (GetComponent<AudioSource>().volume > 0)
        {
            GetComponent<AudioSource>().volume = Mathf.MoveTowards(GetComponent<AudioSource>().volume, 0, _speedVolumeUp);
        
            yield return null;
        }
    }
}
