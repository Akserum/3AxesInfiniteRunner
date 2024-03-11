using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private int currentPositionIndex = 1; // Index de la position initiale du joueur
    public Transform[] targetPositions;
    [SerializeField]
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        if (transform.position.x < targetPositions[0].position.x)
            transform.position = new Vector3(targetPositions[0].position.x, transform.position.y, transform.position.z);
        else if (transform.position.x > targetPositions[2].position.x)
            transform.position = new Vector3(targetPositions[2].position.x, transform.position.y, transform.position.z);


        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveToPosition(-1);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveToPosition(1);
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Debug.Log("test");
        //rb.AddForce(new Vector3(0, 400f), ForceMode.Impulse);

    }
    void MoveToPosition(int direction)
    {
        currentPositionIndex += direction;
        //permet de pas sortir du tabeau
        currentPositionIndex = Mathf.Clamp(currentPositionIndex, 0, targetPositions.Length - 1);
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPositions[currentPositionIndex].position.x, transform.position.y, transform.position.z), 2f);
    }
}