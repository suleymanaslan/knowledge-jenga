using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class StackParser : MonoBehaviour
{
    public TextAsset stackJsonFile; // Reference to the stack.json file
    
    [HideInInspector]
    public List<BlockData> blocks; // List to store parsed data

    public void ParseStacks()
    {
        // Deserialize the JSON file into a list of BlockData objects
        blocks = JsonConvert.DeserializeObject<List<BlockData>>(stackJsonFile.text);

        // Order the stack data based on the specified criteria
        blocks = blocks.OrderBy(data => data.domain)
                       .ThenBy(data => data.cluster)
                       .ThenBy(data => data.standardid)
                       .ToList();
    }

}

[System.Serializable]
public class BlockData
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}
