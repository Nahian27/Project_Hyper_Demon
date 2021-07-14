using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float x, y, z, duration;
    public LeanTweenType ease;

    public void Rotate()
    {
        LeanTween.rotate(gameObject, new Vector3(x, y, z), duration).setEase(ease);
    }
}
