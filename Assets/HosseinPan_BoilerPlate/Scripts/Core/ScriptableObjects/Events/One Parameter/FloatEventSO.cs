using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "FloatEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "Float Event")]
    public class FloatEventSO : BaseEventSO<float> { }
}
