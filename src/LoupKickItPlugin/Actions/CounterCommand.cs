namespace Loupedeck.LoupKickItPlugin
{
    using System;

    // This class implements an example command that counts button presses.

    public class CounterCommand : PluginDynamicCommand
    {
        //private Int32 _counter = 0;
        private String _actionParameter;

        // Initializes the command class.
        public CounterCommand()
            : base(displayName: "FiveM executor", description: "Executes FiveM commands", groupName: "Commands")
        {
            this.MakeProfileAction("text;Enter command.");
        }


        private FiveMConnection connection;
        // This method is called when the user executes the command.
        protected override void RunCommand(String actionParameter)
        {
            this._actionParameter = actionParameter;


            this.connection = new FiveMConnection();
            this.connection.SendMessage(actionParameter);


            //this.ActionImageChanged(); // Notify the Loupedeck service that the command display name and/or image has changed.
            //PluginLog.Info($"Action parameter value is {this._actionParameter}"); // Write the current counter value to the log file.
        }

        // This method is called when Loupedeck needs to show the command on the console or the UI.
        protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize) =>
            $"currentAction{Environment.NewLine}{this._actionParameter}";
    }
}
