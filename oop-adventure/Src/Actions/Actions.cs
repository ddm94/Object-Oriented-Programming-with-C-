
namespace OOPAdventure
{
    // Sealed - this class is unmodifiable
    // Adds another layer of protection to ensure
    // that other classes can not tamper with
    // or extend from classes defined as Singleton
    public sealed class Actions
    {
        private static Actions _instance;

        public static Actions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Actions();

                return _instance;
            }
        }

        private readonly Dictionary<string, Action> _registeredActions = new();

        // Private constructor to ensure there is no way
        // to create  an instance of this class outside of the instance instantiator.
        private Actions() { } 

        public void Register(Action action)
        {
            var name = action.Name.ToLower();

            if (_registeredActions.ContainsKey(name))
                // Replace existing action
                _registeredActions[name] = action;
            else
                // It has not been registered; add it to the dictionary
                _registeredActions.Add(name, action);
        }

        // Execute the actions that the player performs
        public void Execute(string[] args)
        {
            var actionName = args[0];

            if (_registeredActions.ContainsKey(actionName))
                _registeredActions[actionName].Execute(args);
            else
                Console.WriteLine(Text.Language.ActionError);
        }
    }
}
