using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] Player _player;

    private void OnEnable()
    {
        _player.HeadlthChenged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HeadlthChenged -= OnValueChanged;
    }
}
