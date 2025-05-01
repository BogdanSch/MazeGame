namespace MazeGame.Models.GameTools
{
    public class Explosive : Tool
    {
        public event EventHandler? Exploded;
        public Explosive(int damageRadius, double cooldownTime)
        {
            Name = GetType().Name;
            Symbol = '!';
            MessageStyle = new("Red");
            Durability = 100.0f;
            DamageRadius = damageRadius;
            CooldownTime = cooldownTime;
            Cooldown = CooldownTime;
        }
        public override void Use()
        {
            IsActivated = true;
            timer = new Timer(Explode, null, 0, TIMER_STEP);
        }
        private void Explode(object? state)
        {
            if(Cooldown <= 0)
            {
                timer?.Dispose();
                Exploded?.Invoke(this, EventArgs.Empty);
                Exploded = null;
                Durability = 0f;
                //IsUsed = true;
                return;
            }
            Cooldown--;
        }
        //public override void Acivate(Cell cell)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
