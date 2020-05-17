using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlockKing.Detail;

namespace BlockKing.Ui.Pages
{
    public class StatusModel : PageModel
    {
        private readonly BlockKingDbContext _context;
        public StatusModel(BlockKingDbContext context)
        {
            _context = context;
        }
        public IList<Buildings> Buildings { get; set; }

        public void OnGet()
        {
            Buildings = _context.Buildings.ToList();
            //var result = _context.Buildings.ToList();
            //return(result);
        }
        /*       public void OnGet()
               {
               }
           }
       
        [BindProperty]
        public Buildings Buildings() { get; set; }
        
        }
        public class DBinteract
    {
        public static void Hey()
        {
        BlockKingDbContext context = new BlockKingDbContext();
        var query = context.People;
        }
        */
    }
}
