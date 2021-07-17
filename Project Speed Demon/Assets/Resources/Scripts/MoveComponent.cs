using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float speed, safezone, respawnPoint = 350;
    public bool respawn = true;

    private void FixedUpdate()
    {
        transform.position -= transform.forward * (speed - 0.1f);
    }
    private void Update()
    {
        if (transform.position.z <= safezone)
        {
            if (respawn)
                transform.position = new Vector3(0, 0, respawnPoint);

            else Destroy(gameObject);
        }
    }
}
