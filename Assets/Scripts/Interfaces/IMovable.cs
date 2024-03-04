using System;
using System.Collections;
using UnityEngine;

public interface IMovable
{
    public IEnumerator Move(Vector3 targetPos);
}