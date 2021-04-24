using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private bool isLeft;

    public bool IsLeft => isLeft;
    public bool IsRight => !isLeft;
    
    private void Update()
    {
        if (!localInput)
            return;
        if (localInput.horizontal < -0.1f)
            isLeft = true;
        else if (localInput.horizontal > 0.1f)
            isLeft = false;
    }
}