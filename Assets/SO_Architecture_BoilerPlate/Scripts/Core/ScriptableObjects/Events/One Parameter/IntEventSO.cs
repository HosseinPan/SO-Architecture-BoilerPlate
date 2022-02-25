using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "IntEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "Int Event")]
    public class IntEventSO : BaseEventSO<int> { }
}
