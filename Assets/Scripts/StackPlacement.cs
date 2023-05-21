using UnityEngine;
using TMPro;

public class StackPlacement : MonoBehaviour
{
    public GameObject stackPrefab;
    public Vector3 stackOffset;
    public string[] gradeLabels = { "6th Grade", "7th Grade", "8th Grade" };
    public TMP_FontAsset labelFont; // Assign a TextMeshPro font asset for the labels
    public int fontSize;
    private GameObject[] stacks;

    private void Start()
    {
        // Parse the stack data from JSON and order it
        StackParser stackParser = GetComponent<StackParser>();
        stackParser.ParseStacks();

        stacks = new GameObject[gradeLabels.Length];

        // Instantiate stacks with labels
        for (int i = 0; i < gradeLabels.Length; i++)
        {
            // Instantiate stack prefab
            GameObject stack = Instantiate(stackPrefab, transform.position + i * stackOffset, Quaternion.identity);
            stack.name = gradeLabels[i];
            stacks[i] = stack;

            // Create label
            GameObject label = new GameObject("StackLabel");
            label.transform.SetParent(stack.transform);
            label.transform.localPosition = new Vector3(0f, 2.0f, -5.0f);

            // Add TextMeshPro component to the label
            TextMeshPro labelTMP = label.AddComponent<TextMeshPro>();
            labelTMP.text = gradeLabels[i];
            labelTMP.alignment = TextAlignmentOptions.Center;
            labelTMP.font = labelFont;
            labelTMP.fontSize = fontSize;
        }

        // Iterate over the stack data
        for (int i = 0; i < stackParser.blocks.Count; i++)
        {
            BlockData blockData = stackParser.blocks[i];

            // Find the index of the grade label in the array
            int gradeIndex = System.Array.IndexOf(gradeLabels, blockData.grade);
            if (gradeIndex != -1)
            {
                stacks[gradeIndex].GetComponent<Stack>().AddBlock(blockData);
            }
            else
            {
                Debug.Log("Unknown Grade:" + blockData.grade);
            }
        }
        
        CameraOrbitControls cameraOrbitControls = FindObjectOfType<CameraOrbitControls>();
        cameraOrbitControls.SetTargets(stacks);
    }
}
