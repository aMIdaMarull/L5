namespace Lab5
{
    class EquipmentRental
    {
        private readonly ICalculateCostStrategy costStrategy;
        private readonly EquipmentType equipmentType;
        private int rentalTimeInDays;

        public EquipmentRental(ICalculateCostStrategy strategy, EquipmentType equipmentType, int rentalTimeInDays)
        {
            costStrategy = strategy;
            this.equipmentType = equipmentType;
            this.rentalTimeInDays = rentalTimeInDays;
        }

        private double GetEquipmentPrice(EquipmentType equipmentType)
        {
            switch (equipmentType)
            {
                case EquipmentType.Excavator:
                    return 100.0;
                case EquipmentType.Bulldozer:
                    return 150.0;
                case EquipmentType.Crane:
                    return 200.0;
                default:
                    throw new ArgumentException("Invalid equipment type.");
            }
        }

        public double CalculateTotalCost()
        {
            double equipmentPrice = GetEquipmentPrice(equipmentType);
            double baseCost = costStrategy.CalculateCost(equipmentPrice);
            return baseCost * rentalTimeInDays;
        }
    }
}
