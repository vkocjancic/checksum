namespace CheckSum.Common
{
    public static class ArgumentActionFactory
    {

        #region Static methods

        public static ArgumentAction Create(string actionName) {
            var action = ArgumentAction.Undefined;
            if (null != actionName)
            {
                actionName = actionName.ToLower();
                if (("cr" == actionName) || ("create" == actionName))
                {
                    action = ArgumentAction.Create;
                }
                else if (("ch" == actionName) || ("check" == actionName))
                {
                    action = ArgumentAction.Check;
                }
            }
            return action;
        }

        #endregion

    }
}