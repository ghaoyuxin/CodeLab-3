﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Service.AIScript = new AIScript();
        Service.AIScript.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Service.AIScript.Update();

    }
}