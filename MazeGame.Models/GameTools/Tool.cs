using MazeGame.Models.Units;

namespace MazeGame.Models.GameTools
{
    public abstract class Tool : Unit
    {
        public const int TIMER_STEP = 1000;
        public float Durability { get; set; } = 100.0f;
        public int DamageRadius { get; set; } = 1;
        public double CooldownTime { get; protected set; }
        public bool IsActivated { get; protected set; } = false;
        public double Cooldown { get; set; } = 0.0f;
        protected Timer? timer;

        public abstract void Use();
        public virtual void Repair()
        {
            if (Durability < 100.0f)
            {
                Durability += 25.0f;
                if (Durability > 100.0f)
                    Durability = 100.0f;
            }
        }
    }
}
