using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public float playerSpeed = 3;
    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (!isLocalPlayer) return;

        var moveHorizontal = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        var moveVertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position += movement;
    }
}
