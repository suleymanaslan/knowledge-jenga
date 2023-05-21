using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMyStackMode : MonoBehaviour
{
    public Stack selectedStack;

    public void EnableTestMode()
    {
        foreach (GameObject block in selectedStack.blocks)
        {
            if (block.GetComponent<Block>().GetBlockType() == Block.BlockType.Glass)
            {
                Destroy(block.gameObject);
            }
            else
            {
                Rigidbody blockRigidbody = block.GetComponent<Rigidbody>();
                if (blockRigidbody != null)
                {
                    blockRigidbody.isKinematic = false;
                    blockRigidbody.useGravity = true;
                }
            }
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
