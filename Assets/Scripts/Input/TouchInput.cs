using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private GameObject touchPanel;
    [SerializeField] private float durationUntilTouchDisappear = 5;
    private float _timeUntilTouchDisappears;
    private LocalInputReader _localInputReader;
    
    private void OnEnable()
    {
        Input.simulateMouseWithTouches = false;
    }

    public void SetLeft(float value)
    {
        if (_localInputReader) _localInputReader.uiLeft = value;
    }
    
    public void SetRight(float value)
    {
        if (_localInputReader) _localInputReader.uiRight = value;
    }
    
    public void SetJump(bool value)
    {
        if (_localInputReader) _localInputReader.uiJump = value;
    }
    
    public void SetFire1(bool value)
    {
        if (_localInputReader) _localInputReader.uiFire1 = value;
    }

    private void Update()
    {
        if (!_localInputReader)
            _localInputReader = FindObjectOfType<LocalInputReader>();
        
        if (Input.touchCount > 0)
        {
            _timeUntilTouchDisappears = Time.time + durationUntilTouchDisappear;
            touchPanel.SetActive(true);
        }

        if (_timeUntilTouchDisappears <= Time.time)
            touchPanel.SetActive(false);
    }
}
