﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialoug 
{
    public string name;
    [TextArea(2, 10)]
    public string[] sentences;
    public GameObject video;
}
