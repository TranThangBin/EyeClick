using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public interface ILawnAction
    {
        void ActionOnLawn(Transform lawnCell, UnityAction<int> onSuccess);
    }
}