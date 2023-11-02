namespace Lab5
{
    class StandardCostStrategy : ICalculateCostStrategy
    {
        public double CalculateCost(double equipmentPrice)
        {
            return equipmentPrice;
        }
    }
}
