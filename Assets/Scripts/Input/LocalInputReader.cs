using UnityEngine;

public class LocalInputReader : MonoBehaviour
{
    private static LocalInputReader _singleton;

    public LocalInput localInput;
    private bool wasTrigger = false;

    public float uiLeft;
    public float uiRight;
    public bool uiJump;
    public bool uiFire1;
    private bool _wasUiJump;
    private bool _wasUiFire1;

    private bool IsTrigger => Input.GetAxisRaw("Trigger") > 0.1f;

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
        localInput.horizontal = Input.GetAxisRaw("Horizontal") + uiLeft + uiRight;
        localInput.vertical = Input.GetAxisRaw("Vertical");
        localInput.jumpPressed = Input.GetButtonDown("Jump");
        localInput.jumpPressed |= !_wasUiJump && uiJump;
        localInput.attackPressed = Input.GetButtonDown("Fire1");
        localInput.attackPressed |= !_wasUiFire1 && uiFire1;
        localInput.attackPressed |= !wasTrigger && IsTrigger;
        wasTrigger = IsTrigger;
        _wasUiJump = uiJump;
        _wasUiFire1 = uiFire1;
    }
}