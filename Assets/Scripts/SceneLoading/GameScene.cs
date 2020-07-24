using UnityEngine;

public class GameScene : ScriptableObject
{
    [Header("Information")]
    public SceneReference scene;
 
    [Header("Sounds")]
    public AudioClip music;
    [Range(0.0f, 1.0f)]
    public float musicVolume;
}