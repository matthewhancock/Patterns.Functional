namespace Patterns.Functional.Types {
    public abstract class Of<T> {
        protected Of(T Value) => this.Value = Value;

        internal T Value { get; }

        public override bool Equals(object obj)
            => obj != null && this.GetType() == obj.GetType() && (obj as Of<T>).Value.Equals(this.Value);

        public override int GetHashCode()
            => this.GetType().Name.GetHashCode() * Value.GetHashCode();

        public override string ToString() => Value?.ToString();

        public static implicit operator T(Of<T> OfValue) => OfValue.Value;
    }
}
