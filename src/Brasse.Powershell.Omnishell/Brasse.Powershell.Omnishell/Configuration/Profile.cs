using System.Collections.Generic;

namespace Omnishell.Core
{
    internal class Profile
    {
        public Profile()
        {
            Order = new string[0];
            Styles = new Dictionary<string, Style>();
        }

        private string[] order;
        public LinkedList<string> LinkedOrder { get; internal set; }
        public string[] Order
        {
            get { return order; }
            set
            {
                order = value;
                LinkedOrder = new LinkedList<string>(value);
            }
        }
        public Dictionary<string, Style> Styles { get; set; }
    }
}