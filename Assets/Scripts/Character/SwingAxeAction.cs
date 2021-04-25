using System.Collections;
using UnityEngine;

public class SwingAxeAction : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private AudioPlayer swingAxeSound;
    [SerializeField] private float duration = 1;
    [SerializeField] private float cooldown = 1;
    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private Map map;
    private Transform _characterTransform;
    private SwingAxeModel _swingAxeModel;
    private SwingAxeTrigger _swingAxeTrigger;
    private DigTrigger _digTrigger;
    private Direction _direction;
    private Speed _speed;
    private Coroutine _coroutine;
    private float nextSwingTime;
    private bool queueSwing;

    private bool CanSwing => Time.time >= nextSwingTime;

    private void Awake()
    {
        _characterTransform = transform.parent;
        _direction = _characterTransform.GetComponentInChildren<Direction>();
        _speed = _characterTransform.GetComponentInChildren<Speed>();
        _swingAxeModel = GetComponentInChildren<SwingAxeModel>(true);
        _swingAxeTrigger = GetComponentInChildren<SwingAxeTrigger>(true);
        _digTrigger = GetComponentInChildren<DigTrigger>(true);
    }

    private void Update()
    {
        if (CanSwing && queueSwing)
            StartSwingAxe();
        else if (CanSwing && localInput.attackPressed)
            StartSwingAxe();
        else if (!CanSwing && localInput.attackPressed)
            queueSwing = true;
    }

    private void StartSwingAxe()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SwingAxeCoroutine());
        nextSwingTime = Time.time + cooldown / (_speed.Value * speedMultiplier);
        queueSwing = false;
    }

    private IEnumerator SwingAxeCoroutine()
    {
        if (swingAxeSound) swingAxeSound.Play();
        _swingAxeModel.ActivateGameObject();
        _swingAxeTrigger.ActivateGameObject();
        var myTransform = transform;
        var localPosition = myTransform.localPosition;
        var spawnPosition = _direction.IsLeft
            ? _characterTransform.TransformPoint(-localPosition.x, localPosition.y, localPosition.z)
            : myTransform.position;
        _swingAxeTrigger.transform.position = spawnPosition;

        var digInstance = (GameObject) null;
        if (!map.HasDigSquare(spawnPosition))
        {
            var coordinates = map.Dig(spawnPosition);
            spawnPosition = new Vector3((float) coordinates.x / map.cellsPerUnit,
                (float) coordinates.y / map.cellsPerUnit, 0);
            digInstance = _digTrigger.CreateNewActiveDigInstance(spawnPosition, myTransform.lossyScale);
            Destroy(digInstance, duration);
        }

        const float startRotation = -45f;
        var finishRotation = _direction.IsLeft ? startRotation + 135f : startRotation - 135f;
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

        _swingAxeModel.DeactivateGameObject();
        _swingAxeTrigger.DeactivateGameObject();
        _coroutine = null;
    }
}