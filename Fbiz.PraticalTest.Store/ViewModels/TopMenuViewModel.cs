using System.Collections.Generic;

namespace Fbiz.PraticalTest.Store.ViewModels
{
    public class TopMenuViewModel
    {
        public string FatherCategory { get; set; }
        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}