using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ObjectPooler objectPooler;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        var name = eventData.pointerCurrentRaycast.gameObject.name;
        var position = eventData.pointerCurrentRaycast.screenPosition;

        objectPooler.SpawnFromPool(name, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }
}
