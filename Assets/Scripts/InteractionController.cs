using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public Camera camera;
    public MonsterPlane monsterPlane;

    public void OnCapture(InputAction.CallbackContext callback)
    {
        RaycastHit hitInfo;
        if (!Physics.Raycast(this.camera.ScreenPointToRay((Vector3)callback.ReadValue<Vector2>()), out hitInfo) || !(hitInfo.collider.gameObject.tag == "Monster"))
            return;
        Object.Destroy((Object)hitInfo.collider.gameObject);
        this.monsterPlane.SpawnMonster();
    }
}