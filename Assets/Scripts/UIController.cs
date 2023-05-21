using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI detailsText; // Reference to the UI text component

    private float timer = 2f;

    public void UpdateBlockDetails(BlockData blockData)
    {
        string details = $"{blockData.grade}: {blockData.domain}\n" +
                         $"{blockData.cluster}\n" +
                         $"{blockData.standardid}: {blockData.standarddescription}";

        detailsText.text = details;

        detailsText.transform.root.gameObject.SetActive(true);
        timer = 2f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            if (Input.anyKey)
            {
                detailsText.transform.root.gameObject.SetActive(false);
            }
        }
    }
}
