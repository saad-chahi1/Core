using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Wizard
{
    public  class Device : ViewModel
    {
		public string VarName { get; set; }
		public string Description { get; set; }
        public string Parameters { get; set; }



        public bool IsSelected
        {
            get { return this._selected; }
            set { this._selected = value;this.Notify("IsSelected"); }
        }
		private bool _selected=false;
    }
}
