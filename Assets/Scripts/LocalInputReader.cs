using UnityEngine;

public class LocalInputReader : MonoBehaviour
{
    private static LocalInputReader _singleton;

    public LocalInput localInput;

    [RuntimeInitializeOnLoadMethod]
    public static void InitializeOnLoadMethod()
    {
        var localInputPrefab = Resources.Load<GameObject>("Local Input");
        if (_singleton) return;
        var localInput= Instantiate(localInputPrefab);
        localInput.name = localInputPrefab.name;
        DontDestroyOnLoad(localInput);
    }

    private void Awake()
    {
        if (!_singleton)
        {
            _singleton = this;
            return;
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _singleton = null;
    }

    private void Update()
    {
        localInput.horizontal = Input.GetAxisRaw("Horizontal");
        localInput.vertical = Input.GetAxisRaw("Vertical");
        localInput.jumpPressed = Input.GetButtonDown("Jump");
        localInput.attackPressed = Input.GetButtonDown("Fire1");
    }
}