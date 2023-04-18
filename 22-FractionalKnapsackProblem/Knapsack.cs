namespace FractionalKnapsackProblem
{
    public class Item
    {
        public string name;
        public float value;
        public float weight;
        public float ratio;

        public Item(string name, float value, float weight)
        {
            this.name = name;
            this.value = value;
            this.weight = weight;
            ratio = value/weight;
        }
        public override string ToString()
        {
            return $"name: {name}, value: {value}, weight: {weight}, ratio: {ratio}";
        }
    }
    public class Knapsack
    {
        public float maxCapacity = 0;
        public float currentCapacity = 0;
        public float totalValue = 0;
        public List<Item> items = new List<Item>();
        public Knapsack(int maxCapacity)
        {
            this.maxCapacity = maxCapacity;
        }

        public void AddItem(Item item) 
        {
            if (item.weight > this.maxCapacity - this.currentCapacity)
            {
                float available = this.maxCapacity - this.currentCapacity;
                item.weight = available;
                item.value = available * item.ratio;
            }
            items.Add(item);
            this.currentCapacity += item.weight;
            this.totalValue += item.value;
        }
    }
}
