using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaTextUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private int currentDepthLevel = 0;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<DepthText> _depthTexts = new List<DepthText>();
    [SerializeField] private AudioPlayer newAreaSound;

    private float CurrentDepth => player ? player.maxDepth ? player.maxDepth.Value : 0 : 0;

    private void Update()
    {
        if (currentDepthLevel >= _depthTexts.Count) return;
        if (CurrentDepth < _depthTexts[currentDepthLevel].depth) return;
        textMesh.text = _depthTexts[currentDepthLevel].text;
        _animator.Play("Fade");
        newAreaSound.Play();
        currentDepthLevel++;
    }

    [Serializable]
    public class DepthText
    {
        public float depth;
        public string text;
    }
}
