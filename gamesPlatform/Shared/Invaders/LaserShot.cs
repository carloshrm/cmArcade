namespace cmArcade.Shared.Invaders
{
    public partial class LaserShot : GameObject
    {
        public override int row { get; set; }
        public override int col { get; set; }
        public override int healthPoints { get; set; } = 0;
        public override GraphicAsset model { get; set; }
        public override int spriteSelect { get; set; }
        public bool hitSomething { get; set; }
        public bool fromPlayer { get; set; }

        public LaserShot(GameObject actor)
        {
            fromPlayer = actor is PlayerShip;
            row = actor.row;
            col = actor.col + (actor.model.width / 2) - 2;
            model = GameDecal.getInvaderDecal("laser");
            spriteSelect = fromPlayer ? 0 : 1;
        }

        public void hit()
        {
            model = GameDecal.getInvaderDecal("hit");
            spriteSelect = new Random().Next(0, 4);
            hitSomething = true;
        }

        public override bool updatePosition((int row, int col) limits)
        {
            if (!hitSomething)
                row += fromPlayer ? -10 : 6;
            return true;
        }
    }
}
