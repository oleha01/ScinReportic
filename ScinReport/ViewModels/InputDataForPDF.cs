using ScinReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Text;

namespace ScinReport.ViewModels
{
    public class InputDataForPDF
    {
        
        public int Id { get; set; }
        public string Punct1 { get; set; }
        public string Punct2 { get; set; }
        public string Punct3 { get; set; }
        public string Punct4 { get; set; }
        public string Punct5 { get; set; }
        public string Punct7_1 { get; set; }
        public string Punct7_2 { get; set; }
        public string Punct8 { get; set; }
        public string Punct9 { get; set; }
        public string Punct10 { get; set; }
        public bool IsReady { get; set; }
        //virtual public List<Publication> Publications { get; set; }
    }
}
