using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    [SerializeField] protected UnitID unitID;

    public UnitID UnitID { get => unitID; }

    private List<UnitBase> units = new List<UnitBase>();

    public List<UnitBase> UnitList
    {
        get => units;
        set => units = value;
    }

    protected IState iState = null;

    public virtual void SetUp() { }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
