using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "StringIntEvent.asset",
                    menuName = SOMenuItemPaths.EventSO_TwoParameter + "String Int Event")]
    public class StringIntEventSO : BaseEventSO<string, int> { }
}
