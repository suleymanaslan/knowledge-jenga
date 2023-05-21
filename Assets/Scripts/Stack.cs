using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Array of block prefabs for Glass, Wood, Stone
    public List<GameObject> blocks;

    public void AddBlock(BlockData blockData)
    {
        int blockCount = transform.childCount - 1;
        // Calculate the position of the block
        Vector3 blockPosition = transform.position;

        // Instantiate the block prefab
        GameObject block = Instantiate(blockPrefabs[blockData.mastery], blockPosition, Quaternion.identity);
        block.transform.parent = transform;
        block.SetActive(true);
        block.GetComponent<Block>().Initialize(blockData);
        blocks.Add(block);

        // Add blocks in 3x3 grid in the form of a Jenga tower and orient the blocks
        int levelCount = blockCount / 3;
        block.transform.localPosition += Vector3.up * (levelCount * (block.transform.localScale.y + 0.01f));
        float blockOffset = (block.transform.localScale.z + 0.01f) * (blockCount % 3);
        if (levelCount % 2 == 0)
        {
            block.transform.localPosition += Vector3.forward * blockOffset;
            block.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            block.transform.localPosition += Vector3.right * blockOffset;
            block.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            block.transform.position += Vector3.left * (block.transform.localScale.z + 0.01f);
            block.transform.position += Vector3.forward * (block.transform.localScale.z + 0.01f);
        }
    }
}
