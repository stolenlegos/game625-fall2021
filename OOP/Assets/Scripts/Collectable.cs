using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{

    protected int value;
    protected int damage;

    protected abstract void Spin(float rpmX, float rpmY, float rpmZ);
}
