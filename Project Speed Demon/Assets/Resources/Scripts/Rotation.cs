using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject bar;
    public float zRotation, duration;
    public LeanTweenType ease;

    private void OnEnable()
    {
        LeanTween.rotatelocalZ(bar, zRotation, duration).setEase(ease).setLoopPingPong();
    }

}
