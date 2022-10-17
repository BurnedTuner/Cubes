using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class InputToSpawner : MonoBehaviour
{
    [SerializeField] private TMP_InputField _distanceInput;
    [SerializeField] private GameObject _distanceError;
    [SerializeField] private TMP_InputField _speedInput;
    [SerializeField] private GameObject _speedError;
    [SerializeField] private TMP_InputField _timeInput;
    [SerializeField] private GameObject _timeError;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        _speedError.SetActive(false);
        _timeError.SetActive(false);
        _distanceError.SetActive(false);
    }

    public void OnSpeedInput()
    {
        string input = _speedInput.text;
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float newSpeed))
            if (newSpeed > 0)
            {
                _spawner.OnSpeedInput(newSpeed);
                _speedError.SetActive(false);
                return;
            }

        _speedError.SetActive(true);
    }

    public void OnDistanceInput()
    {
        string input = _distanceInput.text;
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float newDistance))
        {
            _spawner.OnDistanceInput(newDistance);
            _distanceError.SetActive(false);
        }
        else
        {
            _distanceError.SetActive(true);
        }
    }

    public void OnTimeInput()
    {
        string input = _timeInput.text;
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float newTime))
            if (newTime > 0)
            {
                _timeError.SetActive(false);
                _spawner.OnTimeInput(newTime);
                return;
            }

        _timeError.SetActive(true);
    }
}
