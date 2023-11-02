namespace Lab5
{
    class PreferentialCostStrategy : ICalculateCostStrategy
    {
        public double CalculateCost(double equipmentPrice)
        {
            return equipmentPrice * 0.9; 
        }
    }
}
