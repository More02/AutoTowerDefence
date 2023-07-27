namespace HP
{
    public struct HealthData
    {
        public float CurrentHealthAsPercange;
        public float CurrentHealth;

        public HealthData(float currentHealthAsPercange, float currentHealth)
        {
            CurrentHealthAsPercange = currentHealthAsPercange;
            CurrentHealth = currentHealth;
        }
    }
}