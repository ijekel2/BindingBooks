using System;
using System.Text;

namespace BindingBooks.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string ButtonSize { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }

        public int? Id { get; set; }
    

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if (Id != null && Id > 0)
                {
                    param.Append(String.Format("{0}", Id));
                }
             
                return param.ToString();

            } 
        }
        
        
    }
}