using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject bar;
    public float distance, duration;
    public bool x;
    public LeanTweenType ease;

    private void OnEnable()
    {
        if(x) LeanTween.moveLocalX(bar, distance, duration).setEase(ease).setLoopPingPong();
        else LeanTween.moveLocalY(bar, distance, duration).setEase(ease).setLoopPingPong();
    }

}
