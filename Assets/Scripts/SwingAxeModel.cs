using UnityEngine;

public class SwingAxeModel : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Rotate(float rotation)
    {
        var eulerAngles = _transform.eulerAngles;
        eulerAngles.z = rotation;
        _transform.eulerAngles = eulerAngles;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}