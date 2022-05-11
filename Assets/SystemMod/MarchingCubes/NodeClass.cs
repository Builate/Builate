using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    /// <summary>
    /// パワー
    /// 0から1までの間でやる
    /// </summary>
    [Range(0,1)]
    public float p;

    public Node()
    {
        p = 0;
    }
}
