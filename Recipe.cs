using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recc
{
    
    public class Recipe
    {
        
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public List<Step> Instructions { get; set; }
        public List<Ingredient> OriginalIngredients { get; set; }

       
    }
}
