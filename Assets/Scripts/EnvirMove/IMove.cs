﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void Move(Vector3 pos, Vector3 pos2, float SpeedTime);
}