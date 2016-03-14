namespace CheckSum.Common
{
    public static class ArgumentActionFactory
    {

        #region Static methods

        public static ArgumentAction Create(string actionName) {
            actionName = actionName.ToLower();
            var action = ArgumentAction.Undefined;
            if (("cr" == actionName) || ("create" == actionName)) {
                action = ArgumentAction.Create;
            }
            else if (("ch" == actionName) || ("check" == actionName)) {
                action = ArgumentAction.Check;
            }
            return action;
        }

        #endregion

    }
}