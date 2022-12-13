namespace Systems.Inputs{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}