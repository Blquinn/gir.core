using System;
using System.Windows.Input;

namespace Gio.Core
{
    public class GCommandAction : GBaseAction
    {
        private ICommand command;
        public GCommandAction(string name, ICommand command) : base(name) 
        {
            this.command = command;
            command.CanExecuteChanged += OnCanExecuteChanged;

            Enabled.Value = command.CanExecute(null);
        }

        protected virtual void OnCanExecuteChanged(object sender, EventArgs args) => Enabled.Value = command.CanExecute(null);
        protected override void OnActivate() => command.Execute(null);

        protected override void Dispose(bool dispsing) 
        {
            base.Dispose(dispsing);

            if(dispsing)
            {
                command.CanExecuteChanged -= OnCanExecuteChanged;
            }
        }
    }
}