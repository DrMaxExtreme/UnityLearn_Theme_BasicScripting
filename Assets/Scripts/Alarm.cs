using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private float _speedVolumeUp;
    private float _volume;
    private int _vloumeSteps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement player))
        {
            Debug.Log("On");
            StopCoroutine(VolumeDown());
            StartCoroutine(VolumeUp());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement player))
        {
            Debug.Log("Off");
            StopCoroutine(VolumeUp());
            StartCoroutine(VolumeDown());
        }
    }

    private IEnumerator VolumeUp()
    {
        for (int i = 0; i < _vloumeSteps; i++)
        {
            GetComponent<AudioSource>().volume = Mathf.MoveTowards(GetComponent<AudioSource>().volume, 100, _speedVolumeUp);

            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        for (int i = 0; i < _vloumeSteps; i++)
        {
            GetComponent<AudioSource>().volume = Mathf.MoveTowards(GetComponent<AudioSource>().volume, 0, _speedVolumeUp);
        
            yield return null;
        }
    }
}
