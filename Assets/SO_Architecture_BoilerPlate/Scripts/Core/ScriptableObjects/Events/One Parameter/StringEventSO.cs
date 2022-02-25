using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "StringEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "String Event")]
    public class StringEventSO : BaseEventSO<string> { }
}
