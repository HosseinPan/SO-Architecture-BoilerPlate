using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "BoolEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "Bool Event")]
    public class BoolEventSO : BaseEventSO<bool> { }
}
