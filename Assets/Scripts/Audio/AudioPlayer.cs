using UnityEngine;

[CreateAssetMenu]
public class AudioPlayer : ScriptableObject
{
    public AudioClip audioClip;
    public float startTime = -1;
    public float endTime = -1;
    public float volume = 1;
    public float pitch = 1;

    public void Play()
    {
        var gameObject = new GameObject(name);
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.time = startTime > 0 ? startTime : 0;
        audioSource.Play();
        var duration = endTime > startTime ? endTime - startTime : audioClip.length;
        Destroy(gameObject, duration);
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(AudioPlayer))]
    public class Editor : UnityEditor.Editor
    {
        private static AudioSource audioSource;
        private float endTime;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Play"))
            {
                var audioPlayer = (AudioPlayer) target;
                if (!audioSource)
                {
                    var gameObject = new GameObject(audioPlayer.audioClip.name);
                    audioSource = gameObject.AddComponent<AudioSource>();
                    gameObject.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy;
                }

                audioSource.clip = audioPlayer.audioClip;
                audioSource.volume = audioPlayer.volume;
                audioSource.pitch = audioPlayer.pitch;
                audioSource.time = audioPlayer.startTime > 0 ? audioPlayer.startTime : 0;
                audioSource.Play();
                endTime = audioPlayer.endTime > audioPlayer.startTime ?
                    audioPlayer.endTime - audioPlayer.startTime + Time.realtimeSinceStartup:
                    audioPlayer.audioClip.length + Time.realtimeSinceStartup;
                UnityEditor.EditorApplication.update -= StopAfterEndTime;
                UnityEditor.EditorApplication.update += StopAfterEndTime;
            }
            else if (GUILayout.Button("Stop"))
            {
                if (audioSource)
                    audioSource.Stop();
            }
        }

        private void StopAfterEndTime()
        {
            if (Time.realtimeSinceStartup < endTime) return;
            if (audioSource) audioSource.Stop();
            UnityEditor.EditorApplication.update -= StopAfterEndTime;
        }
    }
#endif
}