using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "GameObjectIntEvent.asset",
                    menuName = SOMenuItemPaths.EventSO_TwoParameter + "GameObject Int Event")]
    public class GameObjectIntEventSO : BaseEventSO<GameObject, int> { }
}
