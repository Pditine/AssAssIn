using LJH.Scripts.Collide;
using UnityEngine;

namespace LJH.Scripts.Map
{
    public class BarrierThorn : ColliderBase
    {
        [SerializeField] private Barrier theBarrier;
        public Barrier TheBarrier=>theBarrier;
    }
}