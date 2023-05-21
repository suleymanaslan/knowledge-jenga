using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockData blockData; // Reference to the data of the block

    public void Initialize(BlockData data)
    {
        blockData = data;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShowDetails();
        }
    }

    public enum BlockType
    {
        Glass,
        Wood,
        Stone,
        Unknown
    }

    public BlockType GetBlockType()
    {
        switch (blockData.mastery)
        {
            case 0:
                return BlockType.Glass;
            case 1:
                return BlockType.Wood;
            case 2:
                return BlockType.Stone;
            default:
                return BlockType.Unknown;
        }
    }

    private void ShowDetails()
    {
        UIController uiController = FindObjectOfType<UIController>();
        if (uiController != null)
        {
            uiController.UpdateBlockDetails(blockData);
        }
    }
}
