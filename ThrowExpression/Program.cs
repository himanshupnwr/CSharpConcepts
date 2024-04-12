namespace ThrowExpression
{
    class ExpressionMembers
    {
        private String name;
        //private Resource loadedConfig;

        // Throw is now in the initialization expression
        //The preceding construct will cause exception to be thrown during the construction of an object
        // Those are often difficult to recover from. For that reason, designs that throe exceptions during construction
        // are discouraged.
        //private Resource loadedConfig = ConfigResource.LoadConfigResourceOrDefault() ?? throw new InvalidOperationException("Could not load config");

        public ExpressionMembers(string name)
        {
            this.name = name;
            //the old way of placing throw in a constructor
            //loadedConfig = ConfigResource.LoadConfigResourceOrDefault();
            //if (loadedConfig == null)
            //{
            //    throw new InvalidOperationException("Could not load config");
            //}
        }

        public override string ToString() => $"Hello, {name}";

        //Expression-bodied get / set accessor for C# 7.0

        public string Name
        {
            get => name;
            //now throw can be placed in conditional statements
            set => this.name = value ??
            throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        static void Main(string[] args)
        {
            ExpressionMembers exp = new ExpressionMembers("John");
            exp.Name = null;
        }

        private class ConfigResource
        {
            internal static object? LoadConfigResourceOrDefault()
            {
                throw new NotImplementedException();
            }
        }
    }
}
