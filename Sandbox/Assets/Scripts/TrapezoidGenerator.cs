using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 struct position
{
    public float x;
    public float y;
}

struct line
{
    public float length;
    public position midpoint;
    public position end1;
    public position end2;
}


public class TrapezoidGenerator : MonoBehaviour
{
    //Midpoint position
    public Vector2 majorBasePos;
    public float majorBaseLength;

    //public Vector2 minorBasePos;
    public float minorBaseLength;

    public float height;
    public float offset;//x offset between major and minor base

    public float renderDepth;
    line minorBase;
    line majorBase;

    line Leg1;
    line Leg2;

    Vector3 LL1;
    Vector3 LL2;
    Vector3 RL1;
    Vector3 RL2;
    //Build a trapezoid on start up
    // Use this for initialization
    void Start ()
    {
        //majorBasePos.x = 10;
        //majorBasePos.y = 10;        

        //1 - Setting up major and minor bases
        majorBase.length = majorBaseLength;
        majorBase.midpoint.x = majorBasePos.x;
        majorBase.midpoint.y = majorBasePos.y;

        majorBase.end1.x = majorBase.midpoint.x - majorBase.length / 2;
        majorBase.end1.y = majorBase.midpoint.y;

        majorBase.end2.x = majorBase.midpoint.x + majorBase.length / 2;
        majorBase.end2.y = majorBase.midpoint.y;

        

        minorBase.length = minorBaseLength; //set it to 3
        minorBase.midpoint.x = majorBase.midpoint.x + offset;
        minorBase.midpoint.y = majorBase.midpoint.y + height;

        minorBase.end1.x = minorBase.midpoint.x - minorBase.length / 2;
        minorBase.end1.y = minorBase.midpoint.y;

        minorBase.end2.x = minorBase.midpoint.x + minorBase.length / 2;
        minorBase.end2.y = minorBase.midpoint.y;

        //2 - Drawing Legs
        //Left Leg (LL1, LL2)
        LL1 = new Vector3(minorBase.end1.x, minorBase.end1.y, renderDepth);
        LL2 = new Vector3(majorBase.end1.x, majorBase.end1.y, renderDepth);
        RL1 = new Vector3(minorBase.end2.x, minorBase.end2.y, renderDepth);
        RL2 = new Vector3(majorBase.end2.x, majorBase.end2.y, renderDepth);
        Debug.Log("Vec1: "+ LL1 + " Vec2: "+LL2);
        Debug.Log("Vec3: " + RL1 + " Vec4: " + RL2);
        Debug.Log("minorBasePos: (" + minorBase.midpoint.x + " , " + minorBase.midpoint.y + ")");
        Debug.Log("minorBaseEnd1: (" + minorBase.end1.x + " , " + minorBase.end1.y + ")");
        Debug.Log("minorBaseEnd2: (" + minorBase.end2.x + " , " + minorBase.end2.y + ")");
    }
	

    //TODO: Move cloud from left to right
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawLine(LL1, LL2);
        Debug.DrawLine(RL1, RL2);
        Debug.DrawLine(LL1, RL1);
        Debug.DrawLine(LL2, RL2);
    }
}
