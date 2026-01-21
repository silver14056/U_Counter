using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _startCount = 0;

    private int _currentCount;

    public event Action<int> Changed;

    public int StartCout => _startCount;

    private void Awake()
    {
        _currentCount = _startCount;
    }

    public void Count()
    {
        _currentCount++;
        Changed?.Invoke(_currentCount);
    }
}
