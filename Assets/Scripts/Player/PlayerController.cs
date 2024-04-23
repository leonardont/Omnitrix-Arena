using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 20;
    public int attack = 5;
    
    [System.NonSerialized]
    public GameObject mainCamera;
    public Transform attachedCamera;

    public GameObject PlayerDeath;

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float sensitivity = 15f;
    [SerializeField]
    private Transform lookPosition;
    private float rotX, rotY;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.position += transform.right * moveX * moveSpeed * Time.deltaTime;
        transform.position += transform.forward * moveY * moveSpeed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotY += mouseX;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90, 90);

        transform.eulerAngles = new Vector3(0, rotY, 0);
        lookPosition.eulerAngles = new Vector3(rotX, rotY, 0);

        if (health <= 0)
        {
            attachedCamera.parent = null;
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

            Destroy(this.gameObject);

            GameObject PlayerDeathClone = Instantiate(PlayerDeath, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
            Destroy(PlayerDeathClone, 17);
        }
    }
}
