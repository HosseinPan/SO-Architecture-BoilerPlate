using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "TransformEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "Transform Event")]
    public class TransformEventSO : BaseEventSO<Transform> { }
}
