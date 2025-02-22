using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Goods", menuName = "Scriptable Objects/Goods", order = 1)]
public class Goods : ScriptableObject
{
    public List<Level> levels; 


    [System.Serializable]
    public struct Level
    {
        public int clickCountTarget;
        public int sellingPrice;
        public float employeeTimer;
        public int upgradeCost;
    }
}
