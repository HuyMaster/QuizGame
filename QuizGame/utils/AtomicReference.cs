namespace QuizGame.utils
{

    internal class AtomicReference<Type>
    {
        public Type value { get; set; }

        public AtomicReference(Type value)
        {
            this.value = value;
        }
    }
}