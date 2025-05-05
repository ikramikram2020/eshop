using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace eshop2.Models
{
    public class product
    {
        public int Id    { get; set; }
        [Required(ErrorMessage ="veuillez saisir un nom")]
        public string Product_name { get; set; }
        public int Quantite { get; set; }
        [DataType(DataType.MultilineText)]
        public string product_description { get; set; }
        public int prix { get; set; }
        public byte[] produitImage { get; set; }
        public string produitImageType { get; set; }
    }
}


