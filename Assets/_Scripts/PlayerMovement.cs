using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform middle;
    [SerializeField]
    Transform left;
    [SerializeField]
    Transform right;

    Rigidbody rb;
    float force = 10f;
    float speed = 10f;
    [SerializeField] bool canJump = false;
    [SerializeField] bool isRolling = false;

    [SerializeField] BoxCollider boxCollider;

    [SerializeField] Vector3 standingColliderCenter;
    [SerializeField] Vector3 standingColliderSize;

    [SerializeField] Vector3 rollingColliderCenter;
    [SerializeField] Vector3 rollingColliderSize;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        standingColliderCenter = new Vector3(0, 0, 0);
        standingColliderSize = new Vector3(1, 2, 1);

        rollingColliderCenter = new Vector3(0, -0.7f, 0);
        rollingColliderSize = new Vector3(1, 0.6f, 1);
    }

    void FixedUpdate()
    {
        Debug.Log(rb.velocity.y);
        if (canJump && (rb.velocity.y == 0))
        {
            rb.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
            canJump = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            canJump = true;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x >= middle.position.x - 1 && transform.position.x <= middle.position.x + 1)
        {
            transform.position = new Vector3(right.position.x, transform.position.y, transform.position.z);
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x >= left.position.x - 1 && transform.position.x <= left.position.x + 1)
        {
            transform.position = new Vector3(middle.position.x, transform.position.y, transform.position.z);
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x >= middle.position.x - 1 && transform.position.x <= middle.position.x + 1)
        {
            transform.position = new Vector3(left.position.x, transform.position.y, transform.position.z);
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x >= right.position.x - 1 && transform.position.x <= right.position.x + 1)
        {
            transform.position = new Vector3(middle.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isRolling)
        {
            StartCoroutine(Roll());
        }
    }

    IEnumerator Roll()
    {
        isRolling = true;
        boxCollider.center = rollingColliderCenter;
        boxCollider.size = rollingColliderSize;

        yield return new WaitForSeconds(1f);
        boxCollider.center = standingColliderCenter;
        boxCollider.size = standingColliderSize;

        isRolling = false;
    }
}
