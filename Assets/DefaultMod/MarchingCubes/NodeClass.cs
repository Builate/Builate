using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    /// <summary>
    /// �p���[
    /// 0����1�܂ł̊Ԃł��
    /// </summary>
    [Range(0,1)]
    public float p;

    public Node()
    {
        p = 0;
    }
}
