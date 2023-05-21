using UnityEngine;

public class CameraOrbitControls : MonoBehaviour
{
    public GameObject[] targets; // Array of target objects to orbit around
    public float rotationSpeed = 1f; // The speed of rotation

    public Vector3 offset; // The initial offset between the camera and target
    private bool isDragging = false; // Flag to indicate if dragging is in progress
    private int currentTargetIndex = 0; // Index of the current target

    public TestMyStackMode testMyStackMode;

    private void Start()
    {
    }

    public void SetTargets(GameObject[] stacks)
    {
        targets = stacks;
        testMyStackMode.selectedStack = targets[currentTargetIndex].GetComponent<Stack>();
        Reposition();
    }

    private void Reposition()
    {
        transform.position = targets[currentTargetIndex].transform.position + Vector3.up * targets[currentTargetIndex].transform.childCount / 6 + offset;
        transform.LookAt(targets[currentTargetIndex].transform.position + Vector3.up * targets[currentTargetIndex].transform.childCount / 6);
    }

    private void LateUpdate()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Rotate the camera around the current target while dragging
        if (isDragging)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            transform.RotateAround(targets[currentTargetIndex].transform.position, Vector3.up, horizontalInput * rotationSpeed);
            transform.RotateAround(targets[currentTargetIndex].transform.position, transform.right, -verticalInput * rotationSpeed);
        }

        // Check for key input to switch the view between the targets
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchTarget(-1); // Switch to the previous target
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchTarget(1); // Switch to the next target
        }
    }

    private void SwitchTarget(int direction)
    {
        // Increment or decrement the current target index based on the direction
        currentTargetIndex += direction;

        // Wrap the index around if it goes beyond the array bounds
        if (currentTargetIndex < 0)
        {
            currentTargetIndex = targets.Length - 1;
        }
        else if (currentTargetIndex >= targets.Length)
        {
            currentTargetIndex = 0;
        }

        testMyStackMode.selectedStack = targets[currentTargetIndex].GetComponent<Stack>();

        Reposition();
    }
}
