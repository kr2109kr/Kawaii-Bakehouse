using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    [field: SerializeField] public List<Goods> Goods { get; private set; }
}
