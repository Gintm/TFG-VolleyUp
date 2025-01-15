using UnityEngine;

namespace DefaultNamespace
{
    public class ToggleGameObjects
    {
        GameObject one;
        GameObject other;
        
        public ToggleGameObjects(GameObject one, GameObject other)
        {
            this.one = one;
            
            this.other = other;
            other.SetActive(false);
        }
        
        public void Toggle()
        {
            one.SetActive(!one.activeSelf);
            other.SetActive(!other.activeSelf);
        }
    }
}