using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public float horizontalSpeed, forwardSpeed, camRotationDelay;
    public GameObject cmVcam;
    public LeanTweenType vcamEase;
    private bool moveLeft, moveRight, tap = false;
    private bool rotatinOnOff = false;
    private Rigidbody cube;

    void Start()
    {
        moveLeft = moveRight = false;
        cube = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || tap)
        {
            rotatinOnOff = !rotatinOnOff;
            tap = !tap;// toggles onoff at each click

            if (rotatinOnOff || tap)
            {
                Physics.gravity = new Vector3(0, 19.6f, 0);
                LeanTween.rotateZ(cmVcam, 180, camRotationDelay).setEase(vcamEase);
            }
            else
            {
                Physics.gravity = new Vector3(0, -19.6f, 0);
                LeanTween.rotateZ(cmVcam, 0, camRotationDelay).setEase(vcamEase);
            }
        }
    }
    void FixedUpdate()
    {
        if (moveLeft == true || Input.GetKey(KeyCode.LeftArrow))
        {
            if (rotatinOnOff) Hmove(horizontalSpeed);
            else Hmove(-horizontalSpeed);
        }
        if (moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {
            if (!rotatinOnOff) Hmove(horizontalSpeed);
            else Hmove(-horizontalSpeed);
        }

        cube.velocity = new Vector3(cube.velocity.x, cube.velocity.y, forwardSpeed);
    }

    void Hmove(float x)
    {
        //cube.velocity = new Vector3(x, cube.velocity.y, forwardSpeed);
        cube.AddForce(x, 0, 0, ForceMode.Impulse);
    }
    public void LeftPointerDown()
    {
        moveLeft = true;
    }
    public void LeftPointerUp()
    {
        moveLeft = false;
    }
    public void RightPointerDown()
    {
        moveRight = true;
    }
    public void RightPointerUp()
    {
        moveRight = false;
    }
    public void TapPointerDown()
    {
        tap = true;
    }
    public void TapPointerUp()
    {
        tap = false;
    }
}