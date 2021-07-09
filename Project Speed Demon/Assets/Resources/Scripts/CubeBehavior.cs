using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public float horizontalSpeed, forwardSpeed, camRotationDelay;
    public LeanTweenType vcamEase;
    public GameObject cmVcam;
    private bool moveLeft, moveRight, tap = false;
    private bool rotatinOnOff = false;
    private Rigidbody cube;

    private void Awake()
    {
        moveLeft = moveRight = false;
        cube = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || tap == true)
        {
            rotatinOnOff = !rotatinOnOff;
            tap = !tap;

            if (rotatinOnOff == true || tap == true)
            {
                if (Physics.gravity.y == -19.6f)
                {
                    Physics.gravity = new Vector3(0, 19.6f, 0);
                    LeanTween.rotatelocalZ(cmVcam, 180, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.y == 19.6f)
                {
                    Physics.gravity = new Vector3(0, -19.6f, 0);
                    LeanTween.rotatelocalZ(cmVcam, 0, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.x == -19.6f)
                {
                    Physics.gravity = new Vector3(19.6f, 0, 0);
                    LeanTween.rotatelocalZ(cmVcam, -90, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.x == 19.6f)
                {
                    Physics.gravity = new Vector3(-19.6f, 0, 0);
                    LeanTween.rotatelocalZ(cmVcam, 90, camRotationDelay).setEase(vcamEase);
                }
            }
            else
            {
                if (Physics.gravity.y == 19.6f)
                {
                    Physics.gravity = new Vector3(0, -19.6f, 0);
                    LeanTween.rotatelocalZ(cmVcam, 0, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.y == -19.6f)
                {
                    Physics.gravity = new Vector3(0, 19.6f, 0);
                    LeanTween.rotatelocalZ(cmVcam, 180, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.x == 19.6f)
                {
                    Physics.gravity = new Vector3(-19.6f, 0, 0);
                    LeanTween.rotatelocalZ(cmVcam, 90, camRotationDelay).setEase(vcamEase);
                }
                else if (Physics.gravity.x == -19.6f)
                {
                    Physics.gravity = new Vector3(19.6f, 0, 0);
                    LeanTween.rotatelocalZ(cmVcam, -90, camRotationDelay).setEase(vcamEase);
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (moveLeft == true || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Physics.gravity.y == -19.6f) Hmove(-horizontalSpeed, 0);
            else if (Physics.gravity.y == 19.6f) Hmove(horizontalSpeed, 0);

            else if (Physics.gravity.x == -19.6f) Hmove(0, horizontalSpeed);
            else if (Physics.gravity.x == 19.6f) Hmove(0, -horizontalSpeed);
        }
        if (moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {
            if (Physics.gravity.y == -19.6f) Hmove(horizontalSpeed, 0);
            else if (Physics.gravity.y == 19.6f) Hmove(-horizontalSpeed, 0);

            else if (Physics.gravity.x == -19.6f) Hmove(0, -horizontalSpeed);
            else if (Physics.gravity.x == 19.6f) Hmove(0, horizontalSpeed);
        }

        cube.velocity = new Vector3(cube.velocity.x, cube.velocity.y, forwardSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Left Wall"))
        {
            Physics.gravity = new Vector3(-19.6f, 0, 0);
            LeanTween.rotatelocalZ(cmVcam, -90, camRotationDelay / 2).setEase(vcamEase);
        }
        else if (collision.gameObject.CompareTag("Right Wall"))
        {
            Physics.gravity = new Vector3(19.6f, 0, 0);
            LeanTween.rotatelocalZ(cmVcam, 90, camRotationDelay / 2).setEase(vcamEase);
        }
        else if (collision.gameObject.CompareTag("Roof"))
        {
            Physics.gravity = new Vector3(0, 19.6f, 0);
            LeanTween.rotatelocalZ(cmVcam, 180, camRotationDelay / 2).setEase(vcamEase);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Physics.gravity = new Vector3(0, -19.6f, 0);
            LeanTween.rotatelocalZ(cmVcam, 0, camRotationDelay / 2).setEase(vcamEase);
        }
    }

    void Hmove(float x, float y)
    {
        //cube.velocity = new Vector3(x, cube.velocity.y, forwardSpeed);
        cube.AddForce(x, y, 0, ForceMode.Impulse);
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