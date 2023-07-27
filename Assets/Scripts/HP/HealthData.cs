namespace HP
{
    public struct HealthData
    {
        public readonly float CurrentHealthAsPercange;
        public readonly float CurrentHealth;

        public HealthData(float currentHealthAsPercange, float currentHealth)
        {
            CurrentHealthAsPercange = currentHealthAsPercange;
            CurrentHealth = currentHealth;
        }
    }
}