using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Survey_Questionnaire
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer_A { get; set; }
        public string Answer_B { get; set; }
        public string Answer_C { get; set; }
        public string Answer_D { get; set; }
        public string Result { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Creator { get; set; }
    }
}