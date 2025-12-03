using UnityEngine;

public class AddBunnyButton : MonoBehaviour
{

    public BunnyManager BunnyManager;

    private GameObject CurrentDrag;
    

    public void OnMouseDown()
    {
        this.CurrentDrag = this.BunnyManager.PlaceNewBunny();
        
    }

    public void OnMouseUp()
    {
        if(CurrentDrag != null)
        {
            var bunnyControllre = CurrentDrag.GetComponent<BunnyController>();
            bunnyControllre.StopDragging();
        }
    }

}
