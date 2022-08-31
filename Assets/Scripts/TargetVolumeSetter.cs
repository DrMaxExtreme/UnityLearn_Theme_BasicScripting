using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceComponent;

    [SerializeField] private float _speedVolumeUp;
    [SerializeField] private float _targetVolumeActiveAlarm = 1f;
    [SerializeField] private float _targetVolumeInactiveAlarm = 0f;

    private Coroutine _volumeChange;

    public void VolumeChanger(bool alarmActived)
    {
        float targetVolume;

        if (_volumeChange != null) StopCoroutine(_volumeChange);

        if (alarmActived)
            targetVolume = _targetVolumeActiveAlarm;
        else
            targetVolume = _targetVolumeInactiveAlarm;

        _volumeChange = StartCoroutine(VolumeChange(targetVolume));
    }

    private IEnumerator VolumeChange(float targetVolume)
    {
        while (_audioSourceComponent.volume != targetVolume)
        {
            _audioSourceComponent.volume = Mathf.MoveTowards(_audioSourceComponent.volume, targetVolume, _speedVolumeUp * Time.deltaTime);

            yield return null;
        }
    }
}
