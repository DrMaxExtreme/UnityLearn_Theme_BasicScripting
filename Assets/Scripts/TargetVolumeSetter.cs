using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceComponent;

    [SerializeField] private float _speedVolumeUp;

    public IEnumerator VolumeChange(float targetVolume)
    {
        while (_audioSourceComponent.volume != targetVolume)
        {
            _audioSourceComponent.volume = Mathf.MoveTowards(_audioSourceComponent.volume, targetVolume, _speedVolumeUp);

            yield return null;
        }
    }
}
