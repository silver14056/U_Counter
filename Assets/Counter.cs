using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _startCout = 7;

    private int _currentCount;

    public event Action<int> Changed;

    public int StartCout => _startCout;

    private void Awake()
    {
        _currentCount = _startCout;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Count();
    }

    public void Count()
    {
        _currentCount++;
        Changed?.Invoke(_currentCount);
    }
}
