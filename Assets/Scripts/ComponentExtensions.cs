using UnityEngine;

public static class ComponentExtensions
{
    public static void Enable(this Behaviour component)
    {
        component.enabled = true;
    }

    public static void Disable(this Behaviour component)
    {
        component.enabled = false;
    }

    public static void ActivateGameObject(this Component component)
    {
        component.gameObject.SetActive(true);
    }

    public static void DeactivateGameObject(this Component component)
    {
        component.gameObject.SetActive(false);
    }
}