using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSystem : MonoBehaviour
{
    [SerializeField]
    Root baseNode;
    Root nextNode;

    LineRenderer TapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        TapRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextNode == null && Input.GetKeyDown(KeyCode.Space))
        {
            CreateRoot();
            TapRenderer.positionCount = 2;
        }
        else if(nextNode != null)
        {
            var pos = nextNode.GrowthPosition;

            TapRenderer.SetPosition(1, new Vector3(pos.x, pos.y, pos.z));
        }
    }

    void CreateRoot()
    {
        GameObject go = new GameObject("New Root");
        go.transform.SetParent(baseNode.transform);
        go.transform.position = new Vector3(baseNode.transform.position.x, baseNode.transform.position.y - 2, baseNode.transform.position.z);
        nextNode = go.AddComponent<Root>();
    }
}
