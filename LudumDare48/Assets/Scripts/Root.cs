using UnityEngine;

public class Root : MonoBehaviour
{
    //General Root properties
        //Time it takes a root to reach full growth
        //Current Growth status
        //Water growth multiplier (If water supply >= water requirement, growth time enhanced)
        //Nutrient cost to create node
        //Length cost modifier (Greater distance from surface or Primary root, greater cost to create node)
        //Root branches

    //A root can extend outward, but not branch directly
        //On growth completion, a branch node may form depending on settings which branching roots may form from.

    [SerializeField, Tooltip("How many cycles it takes for a root to reach full size.")]
    decimal GrowthTime;
    [SerializeField, Tooltip("The amount of nutrients required to be able to grow a new root.")]
    decimal NutrientCost;
    [SerializeField, Tooltip("The amount of water required to have increased growth speed of a new root.")]
    decimal WaterCost;
    [SerializeField, Range(0,1), Tooltip("The rate at which a sufficient water supply boosts the growth speed of a new root.")]
    decimal WaterGrowthMultiplier;
    [SerializeField, Tooltip("The lower limit of water required until decreased growth speed of a new root.")]
    decimal WaterDeficiency;
    [SerializeField, Range(0,1), Tooltip("The rate at which a deficient water supply slows the growth speed of a new root.")]
    decimal WaterDeficiencyMultiplier;
    [SerializeField, Tooltip("The rate at which the overal length of this section of the root system effects the total cost of root growth.")]
    decimal CostMultiplier;
    [SerializeField]
    bool IsFullGrown;
    [SerializeField]
    bool IsGrowable;

    decimal currentGrowthTime;
    public Vector3 GrowthPosition;

    public Root()
    {
        GrowthTime = 5;
        NutrientCost = 0;
        WaterCost = 0;
        WaterGrowthMultiplier = 0;
        WaterDeficiency = 0;
        WaterDeficiencyMultiplier = 0;
        CostMultiplier = 0;
        IsFullGrown = false;
        IsGrowable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGrowthTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrowable && !IsFullGrown)
        {
            GrowRoot();
        }
    }

    //Grow root by moving the node position to final location - rootLocation - as a percentage by current growth time.
    void GrowRoot()
    {
        if (currentGrowthTime < GrowthTime)
        {
            currentGrowthTime += (decimal)Time.deltaTime;

            var startPos = transform.parent.position;
            var endPos = transform.position;
            var time = (float)currentGrowthTime / (float)GrowthTime;
            GrowthPosition = new Vector3(Mathf.Lerp(startPos.x, endPos.x, time), Mathf.Lerp(startPos.y, endPos.y, time), Mathf.Lerp(startPos.z, endPos.z, time));
        }
        else
        {
            IsFullGrown = true;
            currentGrowthTime = GrowthTime;
        }
    }
}



public class PrimaryRoot: Root
{

}

public class SecondaryRoot : Root
{

}

public class TapRoot : PrimaryRoot
{

}

public class BranchRoot : SecondaryRoot
{

}

public class HairRoot : SecondaryRoot
{

}
