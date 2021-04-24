using System.Collections;
using UnityEngine;

public class SwingAxeAction : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private float duration = 1;
    [SerializeField] private float cooldown = 1;
    private SwingAxeModel _swingAxeModel;
    private SwingAxeTrigger _swingAxeTrigger;
    private Coroutine _coroutine;

    private void Awake()
    {
        _swingAxeModel = GetComponentInChildren<SwingAxeModel>(true);
        _swingAxeTrigger = GetComponentInChildren<SwingAxeTrigger>(true);
    }

    private void Update()
    {
        if (localInput.attackPressed)
            StartSwingAxe();
    }

    private void StartSwingAxe()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SwingAxeCoroutine());
    }

    private IEnumerator SwingAxeCoroutine()
    {
        _swingAxeModel.Enable();
        var startRotation = -45f;
        var finishRotation = startRotation - 135f;
        var startTime = Time.time;
        var finishTime = startTime + duration;
        var time = startTime;
        while (time < finishTime)
        {
            var t = (time - startTime) / duration;
            var newRotation = Mathf.Lerp(startRotation, finishRotation, t);
            _swingAxeModel.Rotate(newRotation);
            yield return null;
            time += Time.deltaTime;
        }
        _swingAxeModel.Disable();
        _coroutine = null;
    }
}