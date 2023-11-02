namespace Lab5
{
    class PenalCostStrategy : ICalculateCostStrategy
    {
        public double CalculateCost(double equipmentPrice)
        {
            return equipmentPrice * 1.2; 
        }
    }
}
