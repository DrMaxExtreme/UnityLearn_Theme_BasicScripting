using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceComponent;

    [SerializeField] private float _speedVolumeUp;

    private Coroutine _volumeChange;

    public void VolumeChanger(bool alarmActived)
    {
        float targetVolumeActiveAlarm = 1f;
        float targetVolumeInactiveAlarm = 0f;
        float targetVolume = 0f;

        if (_volumeChange != null) StopCoroutine(_volumeChange);

        if (alarmActived)
            targetVolume = targetVolumeActiveAlarm;
        else
            targetVolume = targetVolumeInactiveAlarm;

        _volumeChange = StartCoroutine(VolumeChange(targetVolume));
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
