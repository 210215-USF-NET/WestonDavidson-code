using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ToHModels;

namespace ToHMVC.Models
{
    /// <summary>
    /// Model for the index view of my app
    /// </summary>
    public class HeroIndexVM
    {
        //VIEWMODELS CAN BE USED FOR PACKAGING DATA TOGETHER THAT BELONG IN DIFFERENT CLASSES!!! THIS SOUNDS HELPFUL
        //stuff like displayname are called data annotations
        //can be used for display purposes and also for validation
        [DisplayName("Hero Name")]
        public string HeroName { get; set; }
        [DisplayName("Element")]
        public Element ElementType { get; set; }
        [DisplayName("Health Points")]
        public int HP { get; set; }
        
    }
}
