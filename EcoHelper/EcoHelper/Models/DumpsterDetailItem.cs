using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public class DumpsterDetailItem
    {
        public string DumpsterName { get; set; }
        #region Icons
        public string MainIconName { get; set; }
        public string SmallIconLeftUpName { get; set; }
        public string SmallIconLeftDownName { get; set; }
        public string SmallIconRightUpName { get; set; }
        public string SmallIconRightDownName { get; set; }
        public string Subname { get; set; }
        #endregion
        public List<string> ExampleThingsToThrow { get; set; }
        public List<string> ExampleThingsNotToThrow { get; set; }
        public string Tip { get; set; }
        public string WhySegregate{ get; set; }
        public List<string> Curiosities { get; set; }
    }
}
