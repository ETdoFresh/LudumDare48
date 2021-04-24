using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorModel : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private Dictionary<SpriteRenderer, Color> _originalColors = new Dictionary<SpriteRenderer, Color>();

    public void Tint(Color color)
    {
        UpdateLists();
        foreach (var spriteRender in spriteRenderers)
            spriteRender.color = color;
    }

    public void ReturnToNormal()
    {
        foreach(var spriteRenderer in spriteRenderers)
            if (_originalColors.ContainsKey(spriteRenderer))
                spriteRenderer.color = _originalColors[spriteRenderer];
    }
    
    private void UpdateLists()
    {
        foreach(var spriteRenderer in spriteRenderers)
            if (!_originalColors.ContainsKey(spriteRenderer))
                _originalColors.Add(spriteRenderer, spriteRenderer.color);
        
        for (var i= _originalColors.Keys.Count - 1; i >= 0; i--)
            if (!spriteRenderers.Contains(_originalColors.Keys.ElementAt(i)))
                _originalColors.Remove(_originalColors.Keys.ElementAt(i));
    }
}