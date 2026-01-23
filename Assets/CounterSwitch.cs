using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CounterSwitch : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Counter _counter;
    [SerializeField] private CounterView _view;

    private bool _isRunning = false;
    private Coroutine _coroutine;
    private float _interval = 0.5f;
    private bool _isClicked = false;

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
        _isClicked = true;
        Debug.Log("Click" + _isClicked.ToString());
    }

    private void Update()
    {
        if (_isClicked)
        {
            if (_isRunning)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }

            _isClicked = false;
        }
    }

    private void StartCounting()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Counting(_interval));

            _isRunning = true;

            Debug.Log("Start");
        }
    }

    private void StopCounting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;

            _isRunning = false;

            Debug.Log("Stop");
        }
    }

    public IEnumerator Counting(float interval)
    {
        var wait = new WaitForSeconds(interval);
        bool enabled = true;

        while (enabled)
        {
            _counter.Count();
            yield return wait;
        }
    }
}
