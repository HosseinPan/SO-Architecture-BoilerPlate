using UnityEngine;

namespace HosseinPan.Core
{
    [CreateAssetMenu(fileName = "GameObjectEvent.asset", 
                    menuName = SOMenuItemPaths.EventSO_OneParameter + "GameObject Event")]
    public class GameObjectEventSO : BaseEventSO<GameObject> { }
}
