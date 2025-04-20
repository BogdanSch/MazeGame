namespace MazeGame.Models.GameTools
{
    public class Explosive : Tool
    {
        public event EventHandler? Exploded;
        public Explosive(int damageRadius, double cooldownTime)
        {
            Name = GetType().Name;
            Symbol = '!';
            DamageRadius = damageRadius;
            CooldownTime = cooldownTime;
            Cooldown = CooldownTime;
        }
        public override void Use()
        {
            timer = new Timer(Explode, null, 0, TIMER_STEP);
        }
        private void Explode(object? state)
        {
            if(Cooldown <= 0)
            {
                timer?.Dispose();
                Exploded?.Invoke(this, EventArgs.Empty);
                Durability = 0;
                IsUsed = true;
                return;
            }
            Cooldown--;
        }
    }
}
