namespace SaveSystem
{
    public interface ISaveLoadSystem
    {
        public InventoryModel LoadLastInventory();
        public void SaveInventory();
    }
}