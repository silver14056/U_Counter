using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        _counterText.text = _counter.StartCout.ToString("");
    }

    private void OnEnable()
    {
        _counter.Changed += Count;
    }

    private void OnDisable()
    {
        _counter.Changed -= Count;
    }

    private void Count(int currentCount)
    {
        _counterText.text = currentCount.ToString("");
    }
}
