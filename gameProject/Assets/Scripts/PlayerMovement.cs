using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 movement;
    public float speed;
    private PlayerAnimation playerAnimation;
 
    int floorMask;
    float camRayLength = 100f;
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        rigid = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Movement(x,y);
        Turning();
        playerAnimation.Moving(x, y);
      
    }

    private void Movement(float x, float y)
    {
        movement.Set(x, 0, y);
        movement = movement.normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            var rotation = Quaternion.LookRotation(playerToMouse);
            rigid.MoveRotation(rotation);
        }
    }
 
}
