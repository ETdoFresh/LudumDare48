using System.Collections;
using UnityEngine;

public class StunBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private ColorModel colorModel;
    [SerializeField] private bool isStunned;
    [SerializeField] private float pushbackForceMultiplier;
    [SerializeField] private float cooldown = 0.1f;
    [SerializeField] private Color stunColor = Color.red;
    [SerializeField] private AudioPlayer sound;
    private Transform _characterTransform;
    private Coroutine _coroutine;

    public bool IsStunned => isStunned;

    private void Awake()
    {
        _characterTransform = transform.parent;
        rigidbody2D = _characterTransform.GetComponentInChildren<Rigidbody2D>();
        colorModel = _characterTransform.GetComponentInChildren<ColorModel>();
    }

    public void Stun(Damager damager)
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(StunCoroutine(damager));
    }

    private IEnumerator StunCoroutine(Damager damager)
    {
        isStunned = true;
        AddPushbackForce(damager);
        if (sound) sound.Play();
        if (colorModel) colorModel.Tint(stunColor);
        yield return new WaitForSeconds(cooldown);
        if (colorModel) colorModel.ReturnToNormal();
        isStunned = false;
        _coroutine = null;
    }

    private void AddPushbackForce(Damager damager)
    {
        var isLeft = _characterTransform.position.x < damager.transform.position.x;
        var pushbackForce = Vector2.up;
        pushbackForce += isLeft ? Vector2.left : Vector2.right;
        rigidbody2D.AddForce(pushbackForce * pushbackForceMultiplier, ForceMode2D.Impulse);
    }
}